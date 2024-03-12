using AutoMapper;
using Domain.Modules.PlcParameter.Commands;
using Domain.Modules.PlcParameter.Models;
using Domain.Modules.PlcParameter.Queries;
using Domain.Modules.PlcParameter.ViewModels;

namespace Application.Modules.PlcParameter.Mappings
{
    public class PlcParameterProfile : Profile
    {
        public PlcParameterProfile()
        {
            CreateMap<CreatePlcParameterCommand, PlcParameterModel>().ReverseMap();
            CreateMap<UpdatePlcParameterCommand, PlcParameterModel>().ReverseMap();

            CreateMap<PlcParameterViewModel, GetPlcParameterResultById>().ReverseMap();
            CreateMap<CreatePlcParameterCommand, GetPlcParameterResultById>().ReverseMap();

            CreateMap<GetPlcParameterResultById, UpdatePlcParameterCommand>().ReverseMap();
            CreateMap<GetPlcParameterResultAll, UpdatePlcParameterCommand>().ReverseMap();

            CreateMap<PlcParameterModel, GetPlcParameterResultAll>().ReverseMap();
            CreateMap<PlcParameterModel, GetPlcParameterResultById>().ReverseMap();
        }
    }
}