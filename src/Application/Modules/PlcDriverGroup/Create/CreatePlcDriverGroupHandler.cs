using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.PlcDriverGroup.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.PlcDriverGroup.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.PlcDriverGroup.Create
{
    [Serializable]
    public class CreatePlcDriverGroupHandler : BaseCommandHandler, IRequestHandler<CreatePlcDriverGroupCommand, OperationResult>
    {
        public CreatePlcDriverGroupHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreatePlcDriverGroupCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<PlcDriverGroupModel>(command);
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