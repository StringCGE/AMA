using AutoMapper;

using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Application.Services.ClienteApp.Mapping
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            /*CreateMap<Domain.Entities.Cliente, Domain.DTO.Cliente.Dto.ClienteDto>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();

            CreateMap<Domain.DTO.Cliente.Request.ClienteRequest, Domain.Entities.Cliente>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();*/
            
            CreateMap<Domain.DTO.Cliente.FilterDto.ClienteFilter, Domain.Entities.Cliente>().IgnoreIfEmpty();
            
            CreateMap<Domain.Entities.Cliente, Domain.DTO.Cliente.FilterDto.ClienteFilter>().IgnoreIfEmpty();
        }
    }
}