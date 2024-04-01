using AutoMapper;
using Domain.Modules.Identity;
using Domain.Modules.SignIn.Queries;
using Domain.Modules.SignIn.ViewModels;

namespace Application.Modules.SignIn.Mappings
{
    public class SignInProfile : Profile
    {
        public SignInProfile()
        {
            CreateMap<SignInViewModel, GetSignInResultById>().ReverseMap();

            CreateMap<User, GetSignInResultById>()
                .ForMember(dest => dest.EmailSignIn, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordSignIn, act => act.MapFrom(src => src.PasswordHash));

            CreateMap<GetSignInResultById, User>()
               .ForMember(dest => dest.Email, act => act.MapFrom(src => src.EmailSignIn))
               .ForMember(dest => dest.PasswordHash, act => act.MapFrom(src => src.PasswordSignIn));
        }
    }
}