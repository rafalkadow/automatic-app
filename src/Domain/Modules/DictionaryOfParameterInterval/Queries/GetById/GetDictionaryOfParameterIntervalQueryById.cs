using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.DictionaryOfParameterInterval.Queries
{
    [Serializable]
    public class GetDictionaryOfParameterIntervalQueryById : GetDictionaryOfParameterIntervalBaseFilter, IQuery, IRequest<GetDictionaryOfParameterIntervalResultById>
    {
        public GetDictionaryOfParameterIntervalQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}