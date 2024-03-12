using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriver.Commands;
using Shared.Models;
using Application.Modules.Base.Seeder;
using Application.Modules.PlcDriver.Create;
using Application.Modules.PlcDriverGroup.Queries;
using Domain.Modules.PlcDriverGroup.Queries;
using Shared.Helpers;

namespace Application.Modules.PlcDriver.Seeder
{
    [Serializable]
    public class PlcDriverSeederData : BaseSeederClass
    {
        public PlcDriverSeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Data()
        {
            logger.Info($"Data()");
            try
            {
                var getHandlerAll = new GetPlcDriverGroupQueryAllHandler(DbContext, Mapper, UserAccessor);
                var groupList = await getHandlerAll.Handle(new GetPlcDriverGroupQueryAll(), CancellationToken.None);
                var commandHandlerPlcDriver = new CreatePlcDriverHandler(DbContext, Mapper, UserAccessor);

                for (int i = 0; i < 100; i++)
                {
                    var random = new Random();
                    var generator = new RandomGenerator();

                    var item = new CreatePlcDriverCommand() { Name = $"PlcDriver{i + 1}", Description = $"Description{i + 1}", };
                    int groupIndex = random.Next(maxValue: groupList.Count);
                    item.PlcDriverGroupId = groupList[groupIndex].Id;
                    
                    var result = await commandHandlerPlcDriver.Handle(item, CancellationToken.None);
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