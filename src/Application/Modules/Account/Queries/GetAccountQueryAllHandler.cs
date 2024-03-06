using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Account;
using Domain.Modules.Account.Queries;
using Microsoft.EntityFrameworkCore;
using Domain.Modules.Base.Extensions;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.Account.Queries
{
    [Serializable]
    public class GetAccountQueryAllHandler : BaseQueryHandler, IRequestHandler<GetAccountQueryAll, IList<GetAccountResultAll>>
    {
        public GetAccountQueryAllHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<IList<GetAccountResultAll>> Handle(GetAccountQueryAll filter, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                var list = this.DbContext.GetQueryable<AccountModel>();
                var query = list.Where(x =>
                                (string.IsNullOrEmpty(filter.AccountEmail) || (filter.CaseSensitiveComparison ? x.AccountEmail.Equals(filter.AccountEmail) : x.AccountEmail.ToUpper().Equals(filter.AccountEmail.ToUpper()))) &&
                                (string.IsNullOrEmpty(filter.FirstName) || (filter.CaseSensitiveComparison ? x.FirstName.Contains(filter.FirstName) : x.FirstName.ToUpper().Contains(filter.FirstName.ToUpper()))) &&
                                (string.IsNullOrEmpty(filter.LastName) || (filter.CaseSensitiveComparison ? x.LastName.Contains(filter.LastName) : x.LastName.ToUpper().Contains(filter.LastName.ToUpper()))) &&
                                (filter.CreatedFrom == null || x.CreatedOnDateTimeUTC >= filter.CreatedFrom.Value.ToUniversalTime()) &&
                                (filter.CreatedTo == null || x.CreatedOnDateTimeUTC <= filter.CreatedTo.Value.ToUniversalTime())
                             );
                filter.TotalRecords = query.Count();

                list = query.OrderByTypeSort(y => y.OrderId, filter.OrderSortValue).Skip(filter.DisplayStart);

                if (filter.DisplayLengthActive)
                    list = list.Take(filter.DisplayLength);

                var selected = await list.AsNoTracking().ToListAsync();
                //UTC
                var selectedList = selected.Select(x =>
                {
                    return Mapper.Map<GetAccountResultAll>(x);
                }).ToList();
                return selectedList;
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }
    }
}