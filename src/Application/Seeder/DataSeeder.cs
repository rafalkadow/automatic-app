using AutoMapper;
using Domain.Interfaces;
using System.Diagnostics;
using Shared.Models;
using Shared.Enums;
using NLog;
using Application.Modules.PlcDriverGroup.Seeder;
using Application.Modules.PlcDriver.Seeder;
using Domain.Modules.Identity;

namespace Application.Seeder
{
    public class DataSeeder
	{
		public async Task<OperationResult> SeedDataOnApplication(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor, ILogger logger)
		{
			logger.Info($"SeedDataOnApplication()");
			try
			{
				if (!dbContext.GetQueryable<User>().Any())
				{
					var watch = Stopwatch.StartNew();

					//await new AccountSeederData(dbContext, mapper, userAccessor).PrimaryUser();

                    await new PlcDriverGroupSeederData(dbContext, mapper, userAccessor).Data();
                    await new PlcDriverSeederData(dbContext, mapper, userAccessor).Data();

                    //await new AccountSeederData(dbContext, mapper, userAccessor).Data();

					//ToAddData
					watch.Stop();
					logger.Info($"SeedDataOnApplication : Execution Time: {watch.ElapsedMilliseconds} ms");
				}
			}
			catch (Exception ex)
			{
				logger.Error($"SeedDataOnApplication(ex='{ex.ToString()}')");
				throw;
			}
			return new OperationResult(true, "", OperationEnum.Create);
		}
	}
}