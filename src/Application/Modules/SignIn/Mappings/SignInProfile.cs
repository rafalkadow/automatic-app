using AutoMapper;
using Domain.Modules.Account;
using Domain.Modules.SignIn.Queries;
using Domain.Modules.SignIn.ViewModels;

namespace Application.Modules.SignIn.Mappings
{
    public class SignInProfile : Profile
    {
        public SignInProfile()
        {
            CreateMap<SignInViewModel, GetSignInResultById>().ReverseMap();

            CreateMap<AccountModel, GetSignInResultById>()
                .ForMember(dest => dest.EmailSignIn, act => act.MapFrom(src => src.AccountEmail))
                .ForMember(dest => dest.PasswordSignIn, act => act.MapFrom(src => src.AccountPassword));

            CreateMap<GetSignInResultById, AccountModel>()
               .ForMember(dest => dest.AccountEmail, act => act.MapFrom(src => src.EmailSignIn))
               .ForMember(dest => dest.AccountPassword, act => act.MapFrom(src => src.PasswordSignIn));
        }
    }
}