using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcParameter.Commands;
using Shared.Models;
using Application.Modules.Base.Seeder;
using Application.Modules.PlcParameter.Create;
using Application.Modules.PlcDriver.Queries;
using Domain.Modules.PlcDriver.Queries;
using Shared.Helpers;

namespace Application.Modules.PlcParameter.Seeder
{
    [Serializable]
    public class PlcParameterSeederData : BaseSeederClass
    {
        public PlcParameterSeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
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
                var commandHandlerPlcParameter = new CreatePlcParameterHandler(DbContext, Mapper, UserAccessor);

                for (int i = 0; i < 100; i++)
                {
                    var random = new Random();
                    var generator = new RandomGenerator();

                    var item = new CreatePlcParameterCommand() { Name = $"PlcParameter{i + 1}", };
                    int PlcDriverIndex = random.Next(maxValue: groupList.Count);
                    item.PlcDriverId = groupList[PlcDriverIndex].Id;
                    
                    var result = await commandHandlerPlcParameter.Handle(item, CancellationToken.None);
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