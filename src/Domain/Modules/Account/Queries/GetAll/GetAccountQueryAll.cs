using Domain.Modules.Account.Queries.Base;
using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.Account.Queries
{
    [Serializable]
    public class GetAccountQueryAll : GetAccountBaseFilter, IQuery, IRequest<IList<GetAccountResultAll>>
    {
    }
}