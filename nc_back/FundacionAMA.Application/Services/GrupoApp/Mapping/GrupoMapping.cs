using AutoMapper;

using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Application.Services.GrupoApp.Mapping
{
    public class GrupoMapping : Profile
    {
        public GrupoMapping()
        {
            /*CreateMap<Domain.Entities.Grupo, Domain.DTO.Grupo.Dto.GrupoDto>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();

            CreateMap<Domain.DTO.Grupo.Request.GrupoRequest, Domain.Entities.Grupo>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();*/
            
            CreateMap<Domain.DTO.Grupo.FilterDto.GrupoFilter, Domain.Entities.Grupo>().IgnoreIfEmpty();
            
            CreateMap<Domain.Entities.Grupo, Domain.DTO.Grupo.FilterDto.GrupoFilter>().IgnoreIfEmpty();
        }
    }
}