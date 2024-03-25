using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.PlcDriverAlarm.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.PlcDriverAlarm.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcDriverAlarm.Create
{
    [Serializable]
    public class CreatePlcDriverAlarmHandler : BaseCommandHandler, IRequestHandler<CreatePlcDriverAlarmCommand, OperationResult>
    {
        public CreatePlcDriverAlarmHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreatePlcDriverAlarmCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<PlcDriverAlarmModel>(command);
                model.OrderId = await GetOrderIdForTable(model);
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