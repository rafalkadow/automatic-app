using AutoMapper;
using Domain.Modules.Identity;
using Domain.Responses.Identity;

namespace Application.Modules.Identity
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, RoleApp>().ReverseMap();
        }
    }
}