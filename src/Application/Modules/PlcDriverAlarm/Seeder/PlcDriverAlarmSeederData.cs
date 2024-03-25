using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverAlarm.Commands;
using Shared.Models;
using Application.Modules.Base.Seeder;
using Application.Modules.PlcDriverAlarm.Create;

namespace Application.Modules.PlcDriverAlarm.Seeder
{
    [Serializable]
    public class PlcDriverAlarmSeederData : BaseSeederClass
    {
        public PlcDriverAlarmSeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Data()
        {
            logger.Info($"Data()");
            try
            {
                var commandHandlerPlcDriverAlarm = new CreatePlcDriverAlarmHandler(DbContext, Mapper, UserAccessor);

                for (int i = 0; i < 100; i++)
                {
                    var item = new CreatePlcDriverAlarmCommand() { Name = $"PlcDriverAlarm{i + 1}", Description = $"Description{i + 1}", };
                    var result = await commandHandlerPlcDriverAlarm.Handle(item, CancellationToken.None);
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