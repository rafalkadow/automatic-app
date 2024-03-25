using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverAlarm.Models;
using Domain.Modules.PlcDriverAlarm.Queries;
using Microsoft.EntityFrameworkCore;
using Domain.Modules.Base.Extensions;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.PlcDriverAlarm.Queries
{
    [Serializable]
    public class GetPlcDriverAlarmQueryAllHandler : BaseQueryHandler, IRequestHandler<GetPlcDriverAlarmQueryAll, IList<GetPlcDriverAlarmResultAll>>
    {
        public GetPlcDriverAlarmQueryAllHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<IList<GetPlcDriverAlarmResultAll>> Handle(GetPlcDriverAlarmQueryAll filter, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                var list = DbContext.GetQueryable<PlcDriverAlarmModel>().AsNoTracking();

                var query = list.Where(x =>
                                (string.IsNullOrEmpty(filter.Name) || (filter.CaseSensitiveComparison ? x.Name.Contains(filter.Name) : x.Name.ToUpper().Contains(filter.Name.ToUpper()))) &&
                                (string.IsNullOrEmpty(filter.Description) || (filter.CaseSensitiveComparison ? x.Description.Contains(filter.Description) : x.Description.ToUpper().Contains(filter.Description.ToUpper()))) &&
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
                    return Mapper.Map<GetPlcDriverAlarmResultAll>(x);
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