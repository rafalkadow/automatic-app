using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.PlcParameterHistory.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.PlcParameterHistory.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcParameterHistory.Create
{
    [Serializable]
    public class CreatePlcParameterHistoryHandler : BaseCommandHandler, IRequestHandler<CreatePlcParameterHistoryCommand, OperationResult>
    {
        public CreatePlcParameterHistoryHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreatePlcParameterHistoryCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<PlcParameterHistoryModel>(command);
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