using AutoMapper;
using Domain.Modules.Account;
using Domain.Modules.Account.Commands;
using Domain.Modules.Account.Queries;
using Domain.Modules.Account.ViewModels;

namespace Application.Modules.Account.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountCommand, AccountModel>().ReverseMap();
            CreateMap<UpdateAccountCommand, AccountModel>().ReverseMap();
 
            CreateMap<AccountViewModel, GetAccountResultById>().ReverseMap();

            CreateMap<AccountModel, GetAccountResultAll>().ReverseMap();
            CreateMap<AccountModel, GetAccountResultById>().ReverseMap();

            CreateMap<UpdateAccountCommand, GetAccountResultAll>().ReverseMap();
            CreateMap<UpdateAccountCommand, GetAccountResultById>().ReverseMap();
        }
    }
}