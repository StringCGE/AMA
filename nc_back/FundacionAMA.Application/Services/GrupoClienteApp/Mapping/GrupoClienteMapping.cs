using AutoMapper;

using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Application.Services.GrupoClienteApp.Mapping
{
    public class GrupoClienteMapping : Profile
    {
        public GrupoClienteMapping()
        {
            /*CreateMap<Domain.Entities.GrupoCliente, Domain.DTO.GrupoCliente.Dto.GrupoClienteDto>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();

            CreateMap<Domain.DTO.GrupoCliente.Request.GrupoClienteRequest, Domain.Entities.GrupoCliente>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();*/
            
            CreateMap<Domain.DTO.GrupoCliente.FilterDto.GrupoClienteFilter, Domain.Entities.GrupoCliente>().IgnoreIfEmpty();
            
            CreateMap<Domain.Entities.GrupoCliente, Domain.DTO.GrupoCliente.FilterDto.GrupoClienteFilter>().IgnoreIfEmpty();
        }
    }
}