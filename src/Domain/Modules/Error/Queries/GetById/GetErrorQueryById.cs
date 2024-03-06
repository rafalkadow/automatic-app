using Domain.Modules.Account.Queries;
using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.Error.Queries
{
    [Serializable]
    public class GetErrorQueryById : GetErrorBaseFilter, IQuery, IRequest<GetErrorResultById>
    {
    }
}