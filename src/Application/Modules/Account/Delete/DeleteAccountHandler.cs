using AutoMapper;
using Domain.Interfaces;
using Shared.Enums;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Domain.Modules.Account;
using Domain.Modules.Account.Commands;
using NLog;
using Application.Modules.Base.Commands;
using NLog.Filters;

namespace Application.Modules.Account.Delete
{
    [Serializable]
    public class DeleteAccountHandler : BaseCommandHandler, IRequestHandler<DeleteAccountCommand, OperationResult>
    {
        public DeleteAccountHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(DeleteAccountCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                foreach (var guidId in command.GuidList)
                {
                    var model = await DbContext
                                   .GetQueryable<AccountModel>()
                                   .FirstOrDefaultAsync(x => x.Id == guidId);

                    if (model == null || model.Id == Guid.Empty)
                    {
                        return new OperationResult(false);
                    }
                    await DbContext.DeleteAsync(model);
                    await DbContext.SaveChangesAsync();
                }

                return new OperationResult(true, OperationEnum.Delete);
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }
    }
}