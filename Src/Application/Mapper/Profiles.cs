using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Individual, IndividualDto>();
        CreateMap<RelatedIndividual, RelatedIndividualDto>();
        CreateMap<PhoneNumber, PhoneNumberDto>();
    }
}
