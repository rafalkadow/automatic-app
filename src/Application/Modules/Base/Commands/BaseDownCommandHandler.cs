using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Base.Commands;
using Domain.Modules.Base.Models;
using MediatR;
using Shared.Enums;
using Shared.Extensions.GeneralExtensions;
using Shared.Models;

namespace Application.Modules.Base.Commands
{
    [Serializable]
    public class BaseDownCommandHandler : BaseCommandHandler, IRequestHandler<BaseDownCommand, OperationResult>
    {
        public BaseDownCommandHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(BaseDownCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(command='{command.RenderProperties()}')");

            try
            {
                if (command.GuidList == null || !command.GuidList.Any())
                    return new OperationResult(false) { ErrorMessage = "No exists element to action" };

                foreach (var guidId in command.GuidList)
                {
                    var operationCommand = new OperationCommandModel
                    {
                        Id = guidId,
                        Operation = OperationEnum.Down,
                        ControllerName = command.ControllerName,
                    };

                    var result = await CommandChoiceActionAsync(operationCommand);
                    logger.Info($"Handle(result='{result.RenderProperties()}')");
                    if (!result.OperationStatus)
                    {
                        return result;
                    }
                }

                return new OperationResult(true, "", OperationEnum.Delete);
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }

    }
}