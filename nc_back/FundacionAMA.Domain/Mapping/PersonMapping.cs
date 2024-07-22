using AutoMapper;

using FundacionAMA.Domain.DTO.Person.Dto;
using FundacionAMA.Domain.DTO.Person.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<PersonDto, Person>().IgnoreIfEmpty();
            CreateMap<PersonRequest, Person>().IgnoreIfEmpty();
        }
    }
}