using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverAlarm.Models;
using Domain.Modules.PlcDriverAlarm.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.PlcDriverAlarm.Queries
{
    [Serializable]
	public class GetPlcDriverAlarmQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetPlcDriverAlarmQueryById, GetPlcDriverAlarmResultById>
	{
		public GetPlcDriverAlarmQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetPlcDriverAlarmResultById> Handle(GetPlcDriverAlarmQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetPlcDriverAlarmResultById? model = null;
			try
			{
				PlcDriverAlarmModel? modelDb = null;
                var queryable = DbContext.GetQueryable<PlcDriverAlarmModel>().AsNoTracking();
                if (filter.Id != Guid.Empty)
				{
					modelDb = await queryable
                       .FirstOrDefaultAsync(x => x.Id == filter.Id);
				}
				else if (!string.IsNullOrEmpty(filter.Name))
				{
					modelDb = await queryable
					   .FirstOrDefaultAsync(x => x.Name == filter.Name);
				}

                if (modelDb != null)
                    model = Mapper.Map<GetPlcDriverAlarmResultById>(modelDb);

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