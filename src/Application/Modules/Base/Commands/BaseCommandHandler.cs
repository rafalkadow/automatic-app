using Application.Extensions;
using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Base.App;
using Domain.Modules.Base.Commands;
using Domain.Modules.Base.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Extensions.GeneralExtensions;
using Shared.Interfaces;
using Shared.Models;
using System.Reflection;

namespace Application.Modules.Base.Commands
{
    [Serializable]
    public class BaseCommandHandler : BaseApp, IBaseHandlerUtility
    {
        public BaseCommandHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
        {
            DbContext = dbContext;
            Mapper = mapper;
            UserAccessor = userAccessor;
        }

        public async Task<OperationResult> CommandChoiceActionAsync(OperationCommandModel operation)
        {
            logger.Info($"CommandChoiceActionAsync(operation='{operation.RenderProperties()}')");
            try
            {
                string controllerName = operation.ControllerName;
                string objectToInstantiate = $"Domain.Modules.{controllerName}.Models.{controllerName}Model,Domain";

                var objectType = Type.GetType(objectToInstantiate);

                MethodInfo method = typeof(IBaseHandlerUtility).GetMethod(nameof(IBaseHandlerUtility.CommandActionAsync));
                MethodInfo generic = method.MakeGenericMethod(objectType);
                var operationResult = await generic.InvokeAsync<OperationResult>(this, new[] { operation, null });
                if (operationResult != null && operationResult.OperationStatus)
                    return operationResult;
            }
            catch (Exception ex)
            {
                logger.Error($"CommandActionAsync(ex='{ex.ToString()}')");
                throw;
            }
            return new OperationResult(false, "Not exists CommandChoiceActionAsync element");
            //ToAddData
        }


        public async Task<OperationResult> CommandActionAsync<T>(OperationCommandModel commandModel, Func<T, bool> condition = null) where T : class, IEntity
        {
            logger.Info($"CommandActionAsync(commandModel='{commandModel.RenderProperties()}')");
            try
            {
                var controllerName = commandModel.ControllerName;
                var operation = commandModel.Operation;

                var model = DbContext
                    .GetQueryable<T>().AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == commandModel.Id).Result;

                if (model == null || model.Id == Guid.Empty)
                {
                    return new OperationResult(false, "Nie odnaleziono modelu", OperationEnum.Update);
                }
                else if (operation == OperationEnum.Delete)
                {

                    var resultValid = new OperationResult(true);
                    if (resultValid.OperationStatus)
                    {
                        await DbContext.DeleteAsync(model);
                        await DbContext.SaveChangesAsync();
                    }
                    else
                    {
                        return resultValid;
                    }

                    return new OperationResult(true, "", OperationEnum.Delete);
                }
                else
                {
                    return new OperationResult(false, "Not found operation to execution", OperationEnum.Update);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"CommandActionAsync(ex='{ex.ToString()}')");
                throw;
            }
        }

        public Task<ulong> GetOrderIdForTable<T>(T model) where T : class, IEntity
        {
            var queryableBaseModel = DbContext.GetQueryable<T>();
            return GetOrderIdForTable((IQueryable<BaseModel>)queryableBaseModel, model);
        }

        private async Task<ulong> GetOrderIdForTable(IQueryable<BaseModel> queryableBaseModel, IEntity model, ulong orderValue = 0)
        {
            if (orderValue != 0)
            {
                return orderValue;
            }

            ulong orderId = 0;
            if (model.Id != Guid.Empty)
            {
                orderId = await GetOrderIdForGuid(queryableBaseModel, model);
                if (orderId > 0)
                {
                    return orderId;
                }
            }

            orderId = await GetMaxOrderId(queryableBaseModel, model);

            if (orderId == 0)
                orderId = 1;
            else
                orderId += 1;

            return orderId;
        }

        private async Task<ulong> GetMaxOrderId(IQueryable<BaseModel> queryableBaseModel, IEntity model)
        {
            return queryableBaseModel != null && await queryableBaseModel.AsNoTracking()
                .CountAsync() > 0 ? await queryableBaseModel.AsNoTracking().MaxAsync(u => u.OrderId) : 0;
        }

        private async Task<ulong> GetOrderIdForGuid(IQueryable<BaseModel> queryableBaseModel, IEntity model)
        {
            ulong orderId = 0;
            var foundElement = GetElementByGuid(queryableBaseModel, model);
            if (foundElement != null && await foundElement.FirstOrDefaultAsync() != null)
            {
                var foundOrderId = await foundElement.AsNoTracking().FirstOrDefaultAsync();
                orderId = foundOrderId.OrderId;
            }
            return orderId;
        }

        private IQueryable<IEntity> GetElementByGuid(IQueryable<BaseModel> queryableBaseModel, IEntity model)
        {
            return queryableBaseModel?.AsNoTracking().Where(u => u.Id == model.Id);
        }

        internal void ModifiedOrderSet(BaseModel model, BaseModuleCommand baseCommand)
        {
            if (baseCommand.OrderId == 0)
            {
                baseCommand.OrderId = model.OrderId;
            }
        }
    }

}