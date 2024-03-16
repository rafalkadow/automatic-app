using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.DictionaryOfParameterCategory.Queries
{
    [Serializable]
    public class GetDictionaryOfParameterCategoryQueryAll : GetDictionaryOfParameterCategoryBaseFilter, IRequest<IList<GetDictionaryOfParameterCategoryResultAll>>, IQuery
    {
    }
}