using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.DictionaryOfParameterInterval.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.DictionaryOfParameterInterval.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.DictionaryOfParameterInterval.Create
{
    [Serializable]
    public class CreateDictionaryOfParameterIntervalHandler : BaseCommandHandler, IRequestHandler<CreateDictionaryOfParameterIntervalCommand, OperationResult>
    {
        public CreateDictionaryOfParameterIntervalHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreateDictionaryOfParameterIntervalCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<DictionaryOfParameterIntervalModel>(command);
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