using AutoMapper;
using MediatR;
using Shared.Models;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Domain.Interfaces;
using Shared.Extensions.GeneralExtensions;
using Domain.Modules.DictionaryOfParameterCategory.Models;
using Shared.Enums;
using Application.Modules.Base.Commands;

namespace Application.Modules.DictionaryOfParameterCategory.Create
{
    [Serializable]
    public class CreateDictionaryOfParameterCategoryHandler : BaseCommandHandler, IRequestHandler<CreateDictionaryOfParameterCategoryCommand, OperationResult>
    {
        public CreateDictionaryOfParameterCategoryHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(CreateDictionaryOfParameterCategoryCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {

                var model = Mapper.Map<DictionaryOfParameterCategoryModel>(command);
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