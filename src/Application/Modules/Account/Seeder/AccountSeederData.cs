using AutoMapper;
using Application.Modules.Base.Seeder;
using Domain.Interfaces;
using Domain.Modules.Account.Commands;
using Domain.Modules.Account.Consts;
using Domain.Modules.Base.Enums;
using Shared.Models;
using Application.Modules.Account.Update;
using Application.Modules.Account.Create;
using NLog;
using Microsoft.Extensions.Logging;

namespace Application.Modules.Account.Seeder
{
    [Serializable]
    public class AccountSeederData : BaseSeederClass
    {
        public AccountSeederData(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> PrimaryUser()
        {
            logger.Info($"PrimaryUser()");
            try
            {
                UserAccessor.UserGuid = AccountConsts.RootId;
                UserAccessor.UserName = AccountConsts.RootName;

                var commandHandlerAccount = new CreateAccountHandler(DbContext, Mapper, UserAccessor);

                var item = new CreateAccountCommand
                {
                    Id = AccountConsts.RootId,
                    AccountEmail = UserAccessor.UserName,
                    FirstName = $"Admin",
                    LastName = $"Admin",
                    PhoneNumber = "",
                    AccountPassword = AccountConsts.RootPassword,
                    RepeatPassword = AccountConsts.RootPassword,
                    AccountTypeId = (int)AccountTypeEnum.Administrator,
                };

				var accountResult = await commandHandlerAccount.Handle(item, CancellationToken.None);
                if (!accountResult.OperationStatus)
                    return accountResult;
            }
            catch (Exception ex)
            {
                logger.Error($"PrimaryUser(ex='{ex.ToString()}')");
            }
            return new OperationResult(true);
        }

        public async Task<OperationResult> Data()
        {
            logger.Info($"Data()");
            try
            {
                UserAccessor.UserGuid = AccountConsts.RootId;
                UserAccessor.UserName = AccountConsts.RootName;

                var commandHandlerAccountUpdate = new UpdateAccountHandler(DbContext, Mapper, UserAccessor);
                var itemUpdate = new UpdateAccountCommand
                {
                    Id = AccountConsts.RootId,
                    AccountEmail = AccountConsts.RootName,
                    FirstName = $"Admin",
                    LastName = $"Admin",
                    PhoneNumber = "",
                    AccountPassword = AccountConsts.RootPassword,
                    RepeatPassword = AccountConsts.RootPassword,
                    AccountTypeId = (int)AccountTypeEnum.Administrator,
                };

				var accountResult = await commandHandlerAccountUpdate.Handle(itemUpdate, CancellationToken.None);
				if (!accountResult.OperationStatus)
					return accountResult;

				var commandHandlerAccount = new CreateAccountHandler(DbContext, Mapper, UserAccessor);

				var item = new CreateAccountCommand
                {
                    AccountEmail = "test@gmail.com",
                    FirstName = $"Test",
                    LastName = $"Test",
                    PhoneNumber = "",
                    AccountPassword = $"P@$$w0rd",
                    RepeatPassword = $"P@$$w0rd",
                    AccountTypeId = (int)AccountTypeEnum.Administrator,
                };
				accountResult = await commandHandlerAccount.Handle(item, CancellationToken.None);
				if (!accountResult.OperationStatus)
					return accountResult;

            }
            catch (Exception ex)
            {
                logger.Error($"Data(ex='{ex.ToString()}')");
            }
            return new OperationResult(true);
        }

    }
}