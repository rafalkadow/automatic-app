using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Account;
using Domain.Modules.SignIn.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using Application.Modules.Base.Queries;
using MediatR;

namespace Application.Modules.SignIn.Queries
{
    [Serializable]
    public class GetSignInQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetSignInQueryById, GetSignInResultById>
    {
        public GetSignInQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<GetSignInResultById> Handle(GetSignInQueryById filter, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetSignInResultById? model = null;
            try
            {
                AccountModel? modelDb = null;
                var queryable = DbContext.GetQueryable<AccountModel>().AsNoTracking();
                modelDb = await queryable
                    .FirstOrDefaultAsync(x => x.Id == filter.Id);

                if (modelDb != null)
                    model = Mapper.Map<GetSignInResultById>(modelDb);
         
                return model;
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }

    }
}