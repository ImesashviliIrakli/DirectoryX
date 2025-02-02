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
        cancellationToken: cancellationToken
    );

        if (individual is null)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.IndividualNotFound);

        if (request.Image.Length == 0)
            return Result.Failure(GlobalStatusCodes.NotFound, IndividualErrors.ImageShouldNotBeEmpty);

        // Check if an image already exists and remove it
        if (!string.IsNullOrEmpty(individual.ImagePath) && File.Exists(individual.ImagePath))
            File.Delete(individual.ImagePath);

        // Ensure the directory exists
        var directoryPath = Path.Combine(_fileStoragePath);

        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        var filePath = Path.Combine(directoryPath, $"{individual.Id}_{request.Image.FileName}");

        using (var fileStream = new FileStream(filePath, FileMode.Create))
            await request.Image.CopyToAsync(fileStream, cancellationToken);

        individual.UpdateImagePath(filePath);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

