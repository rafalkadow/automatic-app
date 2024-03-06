using AutoMapper;
using Domain.Modules.PlcDriverGroup.Commands;
using Domain.Modules.PlcDriverGroup.Models;
using Domain.Modules.PlcDriverGroup.Queries;
using Domain.Modules.PlcDriverGroup.ViewModels;

namespace Application.Modules.PlcDriverGroup.Mappings
{
    public class PlcDriverGroupProfile : Profile
    {
        public PlcDriverGroupProfile()
        {
            CreateMap<CreatePlcDriverGroupCommand, PlcDriverGroupModel>().ReverseMap();
            CreateMap<UpdatePlcDriverGroupCommand, PlcDriverGroupModel>().ReverseMap();

            CreateMap<PlcDriverGroupViewModel, GetPlcDriverGroupResultById>().ReverseMap();
            CreateMap<CreatePlcDriverGroupCommand, GetPlcDriverGroupResultById>().ReverseMap();

            CreateMap<GetPlcDriverGroupResultById, UpdatePlcDriverGroupCommand>().ReverseMap();
            CreateMap<GetPlcDriverGroupResultAll, UpdatePlcDriverGroupCommand>().ReverseMap();

            CreateMap<PlcDriverGroupModel, GetPlcDriverGroupResultAll>().ReverseMap();
            CreateMap<PlcDriverGroupModel, GetPlcDriverGroupResultById>().ReverseMap();
        }
    }
}