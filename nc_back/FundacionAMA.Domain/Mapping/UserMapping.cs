using AutoMapper;

using FundacionAMA.Domain.DTO.User.Dto;
using FundacionAMA.Domain.DTO.User.Request;
using FundacionAMA.Domain.Shared.Extensions.Mapping;

namespace FundacionAMA.Domain.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserDto, User>().IgnoreIfEmpty();
            CreateMap<UserRequest, User>().IgnoreIfEmpty();
        }
    }
}