using AutoMapper;
using Domain.Modules.PlcParameterHistory.Commands;
using Domain.Modules.PlcParameterHistory.Models;
using Domain.Modules.PlcParameterHistory.Queries;
using Domain.Modules.PlcParameterHistory.ViewModels;

namespace Application.Modules.PlcParameterHistory.Mappings
{
    public class PlcParameterHistoryProfile : Profile
    {
        public PlcParameterHistoryProfile()
        {
            CreateMap<CreatePlcParameterHistoryCommand, PlcParameterHistoryModel>().ReverseMap();
            CreateMap<UpdatePlcParameterHistoryCommand, PlcParameterHistoryModel>().ReverseMap();

            CreateMap<PlcParameterHistoryViewModel, GetPlcParameterHistoryResultById>().ReverseMap();
            CreateMap<CreatePlcParameterHistoryCommand, GetPlcParameterHistoryResultById>().ReverseMap();

            CreateMap<GetPlcParameterHistoryResultById, UpdatePlcParameterHistoryCommand>().ReverseMap();
            CreateMap<GetPlcParameterHistoryResultAll, UpdatePlcParameterHistoryCommand>().ReverseMap();

            CreateMap<PlcParameterHistoryModel, GetPlcParameterHistoryResultAll>().ReverseMap();
            CreateMap<PlcParameterHistoryModel, GetPlcParameterHistoryResultById>().ReverseMap();
        }
    }
}