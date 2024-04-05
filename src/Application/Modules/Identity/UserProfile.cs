using AutoMapper;
using Domain.Modules.Identity;
using Domain.Responses.Identity;

namespace Application.Modules.Identity
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, User>().ReverseMap();
            CreateMap<ChatUserResponse, User>().ReverseMap()
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}