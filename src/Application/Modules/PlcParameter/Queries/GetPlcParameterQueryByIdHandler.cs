using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcParameter.Models;
using Domain.Modules.PlcParameter.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.PlcParameter.Queries
{
    [Serializable]
	public class GetPlcParameterQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetPlcParameterQueryById, GetPlcParameterResultById>
	{
		public GetPlcParameterQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetPlcParameterResultById> Handle(GetPlcParameterQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetPlcParameterResultById? model = null;
			try
			{
				PlcParameterModel? modelDb = null;
				var queryable = DbContext.GetQueryable<PlcParameterModel>().AsNoTracking();
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
                    model = Mapper.Map<GetPlcParameterResultById>(modelDb);

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