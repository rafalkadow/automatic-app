using AutoMapper;
using Domain.Modules.DictionaryOfParameterInterval.Commands;
using Domain.Modules.DictionaryOfParameterInterval.Models;
using Domain.Modules.DictionaryOfParameterInterval.Queries;
using Domain.Modules.DictionaryOfParameterInterval.ViewModels;

namespace Application.Modules.DictionaryOfParameterInterval.Mappings
{
    public class DictionaryOfParameterIntervalProfile : Profile
    {
        public DictionaryOfParameterIntervalProfile()
        {
            CreateMap<CreateDictionaryOfParameterIntervalCommand, DictionaryOfParameterIntervalModel>().ReverseMap();
            CreateMap<UpdateDictionaryOfParameterIntervalCommand, DictionaryOfParameterIntervalModel>().ReverseMap();

            CreateMap<DictionaryOfParameterIntervalViewModel, GetDictionaryOfParameterIntervalResultById>().ReverseMap();
            CreateMap<CreateDictionaryOfParameterIntervalCommand, GetDictionaryOfParameterIntervalResultById>().ReverseMap();

            CreateMap<GetDictionaryOfParameterIntervalResultById, UpdateDictionaryOfParameterIntervalCommand>().ReverseMap();
            CreateMap<GetDictionaryOfParameterIntervalResultAll, UpdateDictionaryOfParameterIntervalCommand>().ReverseMap();

            CreateMap<DictionaryOfParameterIntervalModel, GetDictionaryOfParameterIntervalResultAll>().ReverseMap();
            CreateMap<DictionaryOfParameterIntervalModel, GetDictionaryOfParameterIntervalResultById>().ReverseMap();
        }
    }
}