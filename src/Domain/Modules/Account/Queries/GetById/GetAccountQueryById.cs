using Domain.Modules.Account.Queries.Base;
using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.Account.Queries
{
    [Serializable]
    public class GetAccountQueryById : GetAccountBaseFilter, IQuery, IRequest<GetAccountResultById>
    {
        public GetAccountQueryById(Guid Id)
        {
            this.Id = Id;
        }

        public GetAccountQueryById(string Email)
        {
            this.AccountEmail = Email;
        }

        public GetAccountQueryById()
        {
        }
    }
}