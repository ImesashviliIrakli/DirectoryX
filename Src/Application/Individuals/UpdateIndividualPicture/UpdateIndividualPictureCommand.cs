using Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Http;

namespace Application.Individuals.UpdateIndividualPicture;

public record UpdateIndividualPictureCommand(
        int IndividualId,
        IFormFile Image 
    ) : ICommandQuery;

