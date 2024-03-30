using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcParameterHistory.Models;
using Domain.Modules.PlcParameterHistory.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.PlcParameterHistory.Queries
{
    [Serializable]
	public class GetPlcParameterHistoryQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetPlcParameterHistoryQueryById, GetPlcParameterHistoryResultById>
	{
		public GetPlcParameterHistoryQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetPlcParameterHistoryResultById> Handle(GetPlcParameterHistoryQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetPlcParameterHistoryResultById? model = null;
			try
			{
				PlcParameterHistoryModel? modelDb = null;
				var queryable = DbContext.GetQueryable<PlcParameterHistoryModel>().AsNoTracking();
                if (filter.Id != Guid.Empty)
				{
					modelDb = await queryable
                       .FirstOrDefaultAsync(x => x.Id == filter.Id);
				}

                if (modelDb != null)
                    model = Mapper.Map<GetPlcParameterHistoryResultById>(modelDb);

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