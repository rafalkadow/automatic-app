using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverGroup.Models;
using Domain.Modules.PlcDriverGroup.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.PlcDriverGroup.Queries
{
    [Serializable]
	public class GetPlcDriverGroupQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetPlcDriverGroupQueryById, GetPlcDriverGroupResultById>
	{
		public GetPlcDriverGroupQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetPlcDriverGroupResultById> Handle(GetPlcDriverGroupQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetPlcDriverGroupResultById? model = null;
			try
			{
				PlcDriverGroupModel? modelDb = null;
                var queryable = DbContext.GetQueryable<PlcDriverGroupModel>().AsNoTracking();
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
                    model = Mapper.Map<GetPlcDriverGroupResultById>(modelDb);

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