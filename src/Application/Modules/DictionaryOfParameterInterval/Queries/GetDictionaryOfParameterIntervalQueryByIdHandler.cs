using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.DictionaryOfParameterInterval.Models;
using Domain.Modules.DictionaryOfParameterInterval.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.DictionaryOfParameterInterval.Queries
{
    [Serializable]
	public class GetDictionaryOfParameterIntervalQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetDictionaryOfParameterIntervalQueryById, GetDictionaryOfParameterIntervalResultById>
	{
		public GetDictionaryOfParameterIntervalQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetDictionaryOfParameterIntervalResultById> Handle(GetDictionaryOfParameterIntervalQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetDictionaryOfParameterIntervalResultById? model = null;
			try
			{
				DictionaryOfParameterIntervalModel? modelDb = null;
				var queryable = DbContext.GetQueryable<DictionaryOfParameterIntervalModel>().AsNoTracking();
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
                    model = Mapper.Map<GetDictionaryOfParameterIntervalResultById>(modelDb);

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