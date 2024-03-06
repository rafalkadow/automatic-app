using AutoMapper;
using Domain.Modules.PlcDriver.Commands;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcDriver.Queries;
using Domain.Modules.PlcDriver.ViewModels;

namespace Application.Modules.PlcDriver.Mappings
{
    public class PlcDriverProfile : Profile
    {
        public PlcDriverProfile()
        {
            CreateMap<CreatePlcDriverCommand, PlcDriverModel>().ReverseMap();
            CreateMap<UpdatePlcDriverCommand, PlcDriverModel>().ReverseMap();

            CreateMap<PlcDriverViewModel, GetPlcDriverResultById>().ReverseMap();
            CreateMap<CreatePlcDriverCommand, GetPlcDriverResultById>().ReverseMap();

            CreateMap<GetPlcDriverResultById, UpdatePlcDriverCommand>().ReverseMap();
            CreateMap<GetPlcDriverResultAll, UpdatePlcDriverCommand>().ReverseMap();

            CreateMap<PlcDriverModel, GetPlcDriverResultAll>().ReverseMap();
            CreateMap<PlcDriverModel, GetPlcDriverResultById>().ReverseMap();
        }
    }
}