using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Shared.Models;
using Application.Modules.Base.Seeder;
using Application.Modules.DictionaryOfParameterCategory.Create;
using Application.Modules.PlcDriver.Queries;
using Domain.Modules.PlcDriver.Queries;
using Shared.Helpers;

namespace Application.Modules.DictionaryOfParameterCategory.Seeder
{
    [Serializable]
    public class DictionaryOfParameterCategorySeederData : BaseSeederClass
    {
        public DictionaryOfParameterCategorySeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Data()
        {
            logger.Info($"Data()");
            try
            {
                var getHandlerAll = new GetPlcDriverQueryAllHandler(DbContext, Mapper, UserAccessor);
                var groupList = await getHandlerAll.Handle(new GetPlcDriverQueryAll(), CancellationToken.None);
                var commandHandlerDictionaryOfParameterCategory = new CreateDictionaryOfParameterCategoryHandler(DbContext, Mapper, UserAccessor);

                for (int i = 0; i < 100; i++)
                {
                    var random = new Random();
                    var generator = new RandomGenerator();

                    var item = new CreateDictionaryOfParameterCategoryCommand() { Name = $"DictionaryOfParameterCategory{i + 1}", };
              
                    var result = await commandHandlerDictionaryOfParameterCategory.Handle(item, CancellationToken.None);
                    if (!result.OperationStatus)
                        return result;
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Data(ex='{ex.ToString()}')");
            }
			return new OperationResult(true);
		}
    }
}