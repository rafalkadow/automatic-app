using AutoMapper;
using Application.Extensions;
using Domain.Interfaces;
using Domain.Modules.Account;
using Domain.Modules.Account.Commands;
using Domain.Modules.Base.Enums;
using Shared.Enums;
using Shared.Models;
using Shared.Extensions.EnumExtensions;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Commands;
using NLog.Filters;

namespace Application.Modules.Account.Create
{
    [Serializable]
    public class CreateAccountHandler : BaseCommandHandler, IRequestHandler<CreateAccountCommand, OperationResult>
    {
        public CreateAccountHandler(
            IDbContext dbContext, 
            IMapper mapper, 
            IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                if (string.IsNullOrEmpty(command.AccountTypeName))
                {
                    command.AccountTypeName = command.AccountTypeId.ToEnum<AccountTypeEnum>().ToString();
                }

                command.AccountPassword = command.AccountPassword.Encrypt();

                var model = Mapper.Map<AccountModel>(command);


                await DbContext.CreateAsync(model, UserAccessor);

                return new OperationResult(model, OperationEnum.Create);
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }
    }
}