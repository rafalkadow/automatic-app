using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcParameter.Commands;
using Domain.Modules.PlcParameter.Models;
using Shared.Enums;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcParameter.Delete
{
    [Serializable]
    public class DeletePlcParameterHandler : BaseCommandHandler, IRequestHandler<DeletePlcParameterCommand, OperationResult>// ICommandHandler<UpdatePlcParameterCommand>
    {
        public DeletePlcParameterHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(DeletePlcParameterCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                foreach (var guidId in command.GuidList)
                {
                    var model = await DbContext
                        .GetQueryable<PlcParameterModel>()
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