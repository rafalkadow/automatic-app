using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.PlcParameter.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.PlcParameter.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcParameter.Create
{
    [Serializable]
    public class CreatePlcParameterHandler : BaseCommandHandler, IRequestHandler<CreatePlcParameterCommand, OperationResult>
    {
        public CreatePlcParameterHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreatePlcParameterCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<PlcParameterModel>(command);
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