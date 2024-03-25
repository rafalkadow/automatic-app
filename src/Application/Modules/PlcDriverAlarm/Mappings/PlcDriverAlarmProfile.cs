using AutoMapper;
using Domain.Modules.PlcDriverAlarm.Commands;
using Domain.Modules.PlcDriverAlarm.Models;
using Domain.Modules.PlcDriverAlarm.Queries;
using Domain.Modules.PlcDriverAlarm.ViewModels;

namespace Application.Modules.PlcDriverAlarm.Mappings
{
    public class PlcDriverAlarmProfile : Profile
    {
        public PlcDriverAlarmProfile()
        {
            CreateMap<CreatePlcDriverAlarmCommand, PlcDriverAlarmModel>().ReverseMap();
            CreateMap<UpdatePlcDriverAlarmCommand, PlcDriverAlarmModel>().ReverseMap();

            CreateMap<PlcDriverAlarmViewModel, GetPlcDriverAlarmResultById>().ReverseMap();
            CreateMap<CreatePlcDriverAlarmCommand, GetPlcDriverAlarmResultById>().ReverseMap();

            CreateMap<GetPlcDriverAlarmResultById, UpdatePlcDriverAlarmCommand>().ReverseMap();
            CreateMap<GetPlcDriverAlarmResultAll, UpdatePlcDriverAlarmCommand>().ReverseMap();

            CreateMap<PlcDriverAlarmModel, GetPlcDriverAlarmResultAll>().ReverseMap();
            CreateMap<PlcDriverAlarmModel, GetPlcDriverAlarmResultById>().ReverseMap();
        }
    }
}