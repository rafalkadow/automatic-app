using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.DictionaryOfParameterCategory.Queries
{
    [Serializable]
    public class GetDictionaryOfParameterCategoryQueryById : GetDictionaryOfParameterCategoryBaseFilter, IQuery, IRequest<GetDictionaryOfParameterCategoryResultById>
    {
        public GetDictionaryOfParameterCategoryQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}