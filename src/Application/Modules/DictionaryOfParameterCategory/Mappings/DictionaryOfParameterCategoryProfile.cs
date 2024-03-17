using AutoMapper;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Domain.Modules.DictionaryOfParameterCategory.Models;
using Domain.Modules.DictionaryOfParameterCategory.Queries;
using Domain.Modules.DictionaryOfParameterCategory.ViewModels;

namespace Application.Modules.DictionaryOfParameterCategory.Mappings
{
    public class DictionaryOfParameterCategoryProfile : Profile
    {
        public DictionaryOfParameterCategoryProfile()
        {
            CreateMap<CreateDictionaryOfParameterCategoryCommand, DictionaryOfParameterCategoryModel>().ReverseMap();
            CreateMap<UpdateDictionaryOfParameterCategoryCommand, DictionaryOfParameterCategoryModel>().ReverseMap();

            CreateMap<DictionaryOfParameterCategoryViewModel, GetDictionaryOfParameterCategoryResultById>().ReverseMap();
            CreateMap<CreateDictionaryOfParameterCategoryCommand, GetDictionaryOfParameterCategoryResultById>().ReverseMap();

            CreateMap<GetDictionaryOfParameterCategoryResultById, UpdateDictionaryOfParameterCategoryCommand>().ReverseMap();
            CreateMap<GetDictionaryOfParameterCategoryResultAll, UpdateDictionaryOfParameterCategoryCommand>().ReverseMap();

            CreateMap<DictionaryOfParameterCategoryModel, GetDictionaryOfParameterCategoryResultAll>().ReverseMap();
            CreateMap<DictionaryOfParameterCategoryModel, GetDictionaryOfParameterCategoryResultById>().ReverseMap();
        }
    }
}