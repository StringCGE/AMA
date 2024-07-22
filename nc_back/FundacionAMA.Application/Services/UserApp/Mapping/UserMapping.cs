using AutoMapper;

using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Application.Services.UserApp.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            /*CreateMap<Domain.Entities.User, Domain.DTO.User.Dto.UserDto>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();

            CreateMap<Domain.DTO.User.Request.UserRequest, Domain.Entities.User>()
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(src => src.Donor))
                .ForMember(dest => dest.Volunteer, opt => opt.MapFrom(src => src.Volunteer))
                .IgnoreIfEmpty();*/
            
            CreateMap<Domain.DTO.User.FilterDto.UserFilter, Domain.Entities.User>().IgnoreIfEmpty();
            
            CreateMap<Domain.Entities.User, Domain.DTO.User.FilterDto.UserFilter>().IgnoreIfEmpty();
        }
    }
}