using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.PlcDriver.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.PlcDriver.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcDriver.Create
{
    [Serializable]
    public class CreatePlcDriverHandler : BaseCommandHandler, IRequestHandler<CreatePlcDriverCommand, OperationResult>
    {
        public CreatePlcDriverHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreatePlcDriverCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<PlcDriverModel>(command);
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