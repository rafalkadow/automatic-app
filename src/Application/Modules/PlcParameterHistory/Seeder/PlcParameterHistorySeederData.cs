using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcParameterHistory.Commands;
using Shared.Models;
using Application.Modules.Base.Seeder;
using Application.Modules.PlcParameterHistory.Create;
using Application.Modules.PlcDriver.Queries;
using Domain.Modules.PlcDriver.Queries;
using Shared.Helpers;

namespace Application.Modules.PlcParameterHistory.Seeder
{
    [Serializable]
    public class PlcParameterHistorySeederData : BaseSeederClass
    {
        public PlcParameterHistorySeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
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
                var commandHandlerPlcParameterHistory = new CreatePlcParameterHistoryHandler(DbContext, Mapper, UserAccessor);

                for (int i = 0; i < 100; i++)
                {
                    var random = new Random();
                    var generator = new RandomGenerator();

                    var item = new CreatePlcParameterHistoryCommand() { Name = $"PlcParameterHistory{i + 1}", };
                    int index = random.Next(maxValue: groupList.Count);
                    item.PlcParameterId = groupList[index].Id;
                    
                    var result = await commandHandlerPlcParameterHistory.Handle(item, CancellationToken.None);
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