using Domain.Modules.Error.Queries;
using Domain.Modules.Error.ViewModels;
using AutoMapper;

namespace Application.Modules.Error.Mappings
{
    public class ErrorProfile : Profile
    {
        public ErrorProfile()
        {
            CreateMap<ErrorViewModel, GetErrorResultById>().ReverseMap();
        }
    }
}