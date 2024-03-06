using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverGroup.Commands;
using Domain.Modules.PlcDriverGroup.Models;
using Shared.Enums;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcDriverGroup.Update
{
    [Serializable]
    public class UpdatePlcDriverGroupHandler : BaseCommandHandler, IRequestHandler<UpdatePlcDriverGroupCommand, OperationResult>
    {
        public UpdatePlcDriverGroupHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(UpdatePlcDriverGroupCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                var model = await DbContext
                    .GetQueryable<PlcDriverGroupModel>()
                    .FirstOrDefaultAsync(x => x.Id == command.Id);

                if (model == null || model.Id == Guid.Empty)
                {
                    return new OperationResult(false);
                }
                ModifiedOrderSet(model, command);
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