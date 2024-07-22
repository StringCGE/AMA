using AutoMapper;

using FundacionAMA.Domain.DTO.GrupoCliente.Dto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class GrupoClienteMapping : Profile
    {
        public GrupoClienteMapping()
        {
            CreateMap<GrupoClienteDto, GrupoCliente>().IgnoreIfEmpty();
            CreateMap<GrupoClienteRequest, GrupoCliente>().IgnoreIfEmpty();
        }
    }
}