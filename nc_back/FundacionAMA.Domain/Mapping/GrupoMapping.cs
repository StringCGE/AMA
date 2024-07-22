using AutoMapper;

using FundacionAMA.Domain.DTO.Grupo.Dto;
using FundacionAMA.Domain.DTO.Grupo.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class GrupoMapping : Profile
    {
        public GrupoMapping()
        {
            CreateMap<GrupoDto, Grupo>().IgnoreIfEmpty();
            CreateMap<GrupoRequest, Grupo>().IgnoreIfEmpty();
        }
    }
}