using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.DictionaryOfParameterCategory.Models;
using Domain.Modules.DictionaryOfParameterCategory.Queries;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Queries;

namespace Application.Modules.DictionaryOfParameterCategory.Queries
{
    [Serializable]
	public class GetDictionaryOfParameterCategoryQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetDictionaryOfParameterCategoryQueryById, GetDictionaryOfParameterCategoryResultById>
	{
		public GetDictionaryOfParameterCategoryQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
			: base(dbContext, mapper, userAccessor)
		{
		}

		public async Task<GetDictionaryOfParameterCategoryResultById> Handle(GetDictionaryOfParameterCategoryQueryById filter, CancellationToken cancellationToken)
		{
			logger.Debug($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetDictionaryOfParameterCategoryResultById? model = null;
			try
			{
				DictionaryOfParameterCategoryModel? modelDb = null;
				var queryable = DbContext.GetQueryable<DictionaryOfParameterCategoryModel>().AsNoTracking();
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
                    model = Mapper.Map<GetDictionaryOfParameterCategoryResultById>(modelDb);

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