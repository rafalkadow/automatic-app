using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Account;
using Domain.Modules.Account.Commands;
using Domain.Modules.Base.Enums;
using Shared.Enums;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Application.Extensions;
using Shared.Extensions.EnumExtensions;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Commands;

namespace Application.Modules.Account.Update
{
    [Serializable]
    public class UpdateAccountHandler : BaseCommandHandler, IRequestHandler<UpdateAccountCommand, OperationResult>
    {
        public UpdateAccountHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                var model = await DbContext
                    .GetQueryable<AccountModel>()
                    .FirstOrDefaultAsync(x => x.Id == command.Id);

                if (model == null || model.Id == Guid.Empty)
                {
                    return new OperationResult(false);
                }

                if (command.AccountTypeId != (int)AccountTypeEnum.None && string.IsNullOrEmpty(command.AccountTypeName))
                {
                    command.AccountTypeName = command.AccountTypeId.ToEnum<AccountTypeEnum>().ToString();
                }

                command.AccountPassword = command.AccountPassword.Encrypt();

                await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);

                return new OperationResult(model, OperationEnum.Update);
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }

    }
}