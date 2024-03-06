using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcDriver.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.PlcDriver.Queries
{
    [Serializable]
	public class GetPlcDriverQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetPlcDriverQueryById, GetPlcDriverResultById>
	{
		public GetPlcDriverQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetPlcDriverResultById> Handle(GetPlcDriverQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetPlcDriverResultById? model = null;
			try
			{
				PlcDriverModel? modelDb = null;
				var queryable = DbContext.GetQueryable<PlcDriverModel>().AsNoTracking();
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
                    model = Mapper.Map<GetPlcDriverResultById>(modelDb);

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