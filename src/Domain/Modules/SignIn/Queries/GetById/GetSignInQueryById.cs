using Domain.Modules.PlcDriverGroup.Queries;
using MediatR;
using Shared.Interfaces;

namespace Domain.Modules.SignIn.Queries
{
    [Serializable]
    public class GetSignInQueryById : GetSignInBaseFilter, IQuery, IRequest<GetSignInResultById>
    {
        public GetSignInQueryById(Guid Id)
        {
            this.Id = Id;
        }
    }
}