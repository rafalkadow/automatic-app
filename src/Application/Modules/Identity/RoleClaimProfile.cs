using AutoMapper;
using Domain.Modules.Identity;
using Domain.Requests.Identity;
using Domain.Responses.Identity;

namespace Application.Modules.Identity
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            CreateMap<RoleClaimResponse, RoleAppClaim>()
                .ForMember(nameof(RoleAppClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(RoleAppClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            CreateMap<RoleClaimRequest, RoleAppClaim>()
                .ForMember(nameof(RoleAppClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(RoleAppClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();
        }
    }
}