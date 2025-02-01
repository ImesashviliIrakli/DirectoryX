using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Errors;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace Application.Individuals.UpdateIndividualPicture;

internal sealed class UpdateIndividualPictureCommandHandler(
        IIndividualRepository individualRepository,
        IConfiguration configuration,
        IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<UpdateIndividualPictureCommand>
{
    private readonly IIndividualRepository _individualRepository = individualRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly string _fileStoragePath = configuration["FileStorage:Path"] ?? throw new ArgumentNullException();


    public async Task<Result> Handle(UpdateIndividualPictureCommand request, CancellationToken cancellationToken)
    {
        var individual = await _individualRepository.GetByIdAsync(
            individualId: request.IndividualId, 
            includeDetails: false,
            cancellationToken: cancellationToken
        );

        if (individual is null)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.IndividualNotFound);

        if (request.Image.Length == 0)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.ImageShouldNotBeEmpty);

        var filePath = Path.Combine(_fileStoragePath, $"{individual.Id}_{request.Image.FileName}");

        using (var fileStream = new FileStream(filePath, FileMode.Create))
            await request.Image.CopyToAsync(fileStream, cancellationToken);

        individual.UpdateImagePath(filePath);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

