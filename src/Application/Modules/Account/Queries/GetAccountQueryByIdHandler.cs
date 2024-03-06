using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Account;
using Domain.Modules.Account.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.Account.Queries
{
    [Serializable]
    public class GetAccountQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetAccountQueryById, GetAccountResultById>
    {
        public GetAccountQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<GetAccountResultById> Handle(GetAccountQueryById filter, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetAccountResultById? model = null;
            try
            {
                AccountModel? modelDb = null;
                var queryable = DbContext.GetQueryable<AccountModel>().AsNoTracking();

                if (filter.Id != Guid.Empty)
                {
                    modelDb = await queryable
                       .FirstOrDefaultAsync(x => x.Id == filter.Id);
                }
                else
                {
                    modelDb = await queryable
                       .FirstOrDefaultAsync(x => x.AccountEmail == filter.AccountEmail);
                }

                if (modelDb != null)
                {
                    model = Mapper.Map<GetAccountResultById>(modelDb);
                }

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