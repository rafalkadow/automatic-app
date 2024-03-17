using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Domain.Modules.DictionaryOfParameterCategory.Models;
using Shared.Enums;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Commands;

namespace Application.Modules.DictionaryOfParameterCategory.Delete
{
    [Serializable]
    public class DeleteDictionaryOfParameterCategoryHandler : BaseCommandHandler, IRequestHandler<DeleteDictionaryOfParameterCategoryCommand, OperationResult>// ICommandHandler<UpdateDictionaryOfParameterCategoryCommand>
    {
        public DeleteDictionaryOfParameterCategoryHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(DeleteDictionaryOfParameterCategoryCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                foreach (var guidId in command.GuidList)
                {
                    var model = await DbContext
                        .GetQueryable<DictionaryOfParameterCategoryModel>()
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