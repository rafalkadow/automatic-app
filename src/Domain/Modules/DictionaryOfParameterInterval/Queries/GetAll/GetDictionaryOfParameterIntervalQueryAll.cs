using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.DictionaryOfParameterInterval.Queries
{
    [Serializable]
    public class GetDictionaryOfParameterIntervalQueryAll : GetDictionaryOfParameterIntervalBaseFilter, IRequest<IList<GetDictionaryOfParameterIntervalResultAll>>, IQuery
    {
    }
}