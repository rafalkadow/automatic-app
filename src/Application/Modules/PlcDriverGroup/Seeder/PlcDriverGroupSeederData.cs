using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverGroup.Commands;
using Shared.Models;
using Application.Modules.Base.Seeder;
using Application.Modules.PlcDriverGroup.Create;

namespace Application.Modules.PlcDriverGroup.Seeder
{
    [Serializable]
    public class PlcDriverGroupSeederData : BaseSeederClass
    {
        public PlcDriverGroupSeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Data()
        {
            logger.Info($"Data()");
            try
            {
                var commandHandlerPlcDriverGroup = new CreatePlcDriverGroupHandler(DbContext, Mapper, UserAccessor);

                for (int i = 0; i < 100; i++)
                {
                    var item = new CreatePlcDriverGroupCommand() { Name = $"PlcDriverGroup{i + 1}", Description = $"Description{i + 1}", };
                    var result = await commandHandlerPlcDriverGroup.Handle(item, CancellationToken.None);
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