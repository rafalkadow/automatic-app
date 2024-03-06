using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverGroup.Commands;
using Domain.Modules.PlcDriverGroup.Models;
using Shared.Enums;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using NLog;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcDriverGroup.Delete
{
    [Serializable]
    public class DeletePlcDriverGroupHandler : BaseCommandHandler, IRequestHandler<DeletePlcDriverGroupCommand, OperationResult>
    {
        public DeletePlcDriverGroupHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(DeletePlcDriverGroupCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                foreach (var guidId in command.GuidList)
                {
                    var model = await DbContext
                        .GetQueryable<PlcDriverGroupModel>()
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