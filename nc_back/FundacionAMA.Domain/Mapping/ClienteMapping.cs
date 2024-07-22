using AutoMapper;

using FundacionAMA.Domain.DTO.Cliente.Dto;
using FundacionAMA.Domain.DTO.Cliente.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            CreateMap<ClienteDto, Cliente>().IgnoreIfEmpty();
            CreateMap<ClienteRequest, Cliente>().IgnoreIfEmpty();
        }
    }
}