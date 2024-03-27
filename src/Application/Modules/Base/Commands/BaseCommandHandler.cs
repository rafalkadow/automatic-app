using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Base.App;
using Domain.Modules.Base.Commands;
using Domain.Modules.Base.Enums;
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
                    return new OperationResult(false, "Not found module", OperationEnum.Update);
                }
                else if (operation == OperationEnum.Active)
                {
                    var result = await ActiveMethod(model);
                    return result;
                }
                else if (operation == OperationEnum.Inactive)
                {
                    var result = await InactiveMethod(model);
                    return result;
                }
                else if (operation == OperationEnum.Archive)
                {
                    var result = await ArchiveMethod(model);
                    return result;
                }
                else if (operation == OperationEnum.Up)
                {
                    var result = await UpMethod(condition, controllerName, model);
                    return result;
                }
                else if (operation == OperationEnum.Down)
                {
                    var result = await DownMethod(condition, controllerName, model);
                    return result;
                }
                else if (operation == OperationEnum.First)
                {
                    var result = await FirstMethod(condition, controllerName, model);
                    return result;
                }
                else if (operation == OperationEnum.Last)
                {
                    var result = await LastMethod(condition, controllerName, model);
                    return result;
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

        private async Task<OperationResult> ActiveMethod<T>(T model) where T : class, IEntity
        {
            var command = new BaseActiveCommand
            {
                RecordStatus = RecordStatusEnum.Actived
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);
            return new OperationResult(true);
        }

        private async Task<OperationResult> InactiveMethod<T>(T model) where T : class, IEntity
        {
            var command = new BaseInactiveCommand
            {
                RecordStatus = RecordStatusEnum.Inactived
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);
            return new OperationResult(true);
        }

        private async Task<OperationResult> ArchiveMethod<T>(T model) where T : class, IEntity
        {
            var command = new BaseArchiveCommand
            {
                RecordStatus = RecordStatusEnum.Archived
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);
            return new OperationResult(true);
        }


        private async Task<OperationResult> UpMethod<T>(Func<T, bool> condition, string controllerName, T model) where T : class, IEntity
        {
            IQueryable<T> iQuery = (IQueryable<T>)DbContext.GetQueryable<T>().AsNoTracking();
            if (condition != null)
                iQuery = DbContext.GetQueryable<T>().AsNoTracking().Where(condition).AsQueryable();

            var orderSort = OrderSortEnum.Desc;
 

            var command = new BaseUpCommand
            {
                OrderId = await ChangeOrderId(iQuery, model, OrderIdDirectionEnum.Up, orderSort),
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);

            return new OperationResult(true);
        }

        private async Task<OperationResult> DownMethod<T>(Func<T, bool> condition, string controllerName, T model) where T : class, IEntity
        {
            IQueryable<T> iQuery = (IQueryable<T>)DbContext.GetQueryable<T>().AsNoTracking();
            if (condition != null)
                iQuery = DbContext.GetQueryable<T>().AsNoTracking().Where(condition).AsQueryable();

            var orderSort = OrderSortEnum.Desc;

            var command = new BaseDownCommand
            {
                OrderId = await ChangeOrderId(iQuery, model, OrderIdDirectionEnum.Down, orderSort),
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);

            return new OperationResult(true);
        }

        private async Task<OperationResult> FirstMethod<T>(Func<T, bool> condition, string controllerName, T model) where T : class, IEntity
        {
            IQueryable<T> iQuery = (IQueryable<T>)DbContext.GetQueryable<T>().AsNoTracking();
            if (condition != null)
                iQuery = DbContext.GetQueryable<T>().AsNoTracking().Where(condition).AsQueryable();

            var orderSort = OrderSortEnum.Desc;
 
            var command = new BaseUpCommand
            {
                OrderId = await ChangeOrderId(iQuery, model, OrderIdDirectionEnum.First, orderSort),
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);
            return new OperationResult(true);
        }

        private async Task<OperationResult> LastMethod<T>(Func<T, bool> condition, string controllerName, T model) where T : class, IEntity
        {
            IQueryable<T> iQuery = (IQueryable<T>)DbContext.GetQueryable<T>().AsNoTracking();
            if (condition != null)
                iQuery = DbContext.GetQueryable<T>().AsNoTracking().Where(condition).AsQueryable();

            var orderSort = OrderSortEnum.Desc;
         
            var command = new BaseDownCommand
            {
                OrderId = await ChangeOrderId(iQuery, model, OrderIdDirectionEnum.Last, orderSort),
            };
            await DbContext.UpdatePropertiesAsync(model, command, UserAccessor);
            return new OperationResult(true);
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


        public async Task<ulong> ChangeOrderId<T>(IQueryable<T> ts, T model, OrderIdDirectionEnum operation, OrderSortEnum orderSort = OrderSortEnum.Desc) where T : class, IEntity
        {
            ulong orderId = GetOrderIdForGuid(ts, model);

            if (ts == null)
                return 0;

            IQueryable<BaseModel> foundElement;

            if (orderSort == OrderSortEnum.Asc)
            {
                switch (operation)
                {
                    case OrderIdDirectionEnum.Down:
                        operation = OrderIdDirectionEnum.Up;
                        break;

                    case OrderIdDirectionEnum.Last:
                        operation = OrderIdDirectionEnum.First;
                        break;

                    case OrderIdDirectionEnum.Up:
                        operation = OrderIdDirectionEnum.Down;
                        break;

                    case OrderIdDirectionEnum.First:
                        operation = OrderIdDirectionEnum.Last;
                        break;

                    default:
                        return orderId;
                }
            }

            switch (operation)
            {
                case OrderIdDirectionEnum.Down:
                    foundElement = (IQueryable<BaseModel>)ts.Where(u => u.OrderId < orderId).OrderByDescending(x => x.OrderId);
                    break;

                case OrderIdDirectionEnum.Last:
                    foundElement = (IQueryable<BaseModel>)ts.Where(u => u.OrderId < orderId).OrderByDescending(x => x.OrderId);
                    break;

                case OrderIdDirectionEnum.Up:
                    foundElement = (IQueryable<BaseModel>)ts.Where(u => u.OrderId > orderId).OrderBy(x => x.OrderId);
                    break;

                case OrderIdDirectionEnum.First:
                    foundElement = (IQueryable<BaseModel>)ts.Where(u => u.OrderId > orderId).OrderByDescending(x => x.OrderId);
                    break;

                default:
                    return orderId;
            }

            if (foundElement.Count() == 0)
                return orderId;

            ulong orderIdReturn = 0;

            if (operation == OrderIdDirectionEnum.First)
            {
                var listElement = foundElement.ToList();
                var elementFirst = listElement.FirstOrDefault();
                if (elementFirst != null)
                {
                    orderIdReturn = elementFirst.OrderId;
                }

                for (int i = 0; i < listElement.Count; i++)
                {
                    var element = listElement[i];

                    if (element != null)
                    {
                        ulong newOrderId = 0;
                        if (i < listElement.Count - 1)
                        {
                            newOrderId = listElement[i + 1].OrderId;
                        }
                        else
                        {
                            newOrderId = orderId;
                        }

                        var command = new BaseUpDownCommand()
                        {
                            OrderId = newOrderId,
                        };
                        await DbContext.UpdatePropertiesAsync(element, command, UserAccessor);
                    }
                }
            }
            else if (operation == OrderIdDirectionEnum.Last)
            {
                var listElement = foundElement.ToList();
                var elementLast = listElement.LastOrDefault();
                if (elementLast != null)
                {
                    orderIdReturn = elementLast.OrderId;
                }

                for (int i = listElement.Count - 1; i >= 0; i--)
                {
                    var element = listElement[i];

                    if (element != null)
                    {
                        ulong newOrderId = 0;
                        if (i > 0)
                        {
                            newOrderId = listElement[i - 1].OrderId;
                        }
                        else
                        {
                            newOrderId = orderId;
                        }

                        var command = new BaseUpDownCommand()
                        {
                            OrderId = newOrderId,
                        };
                        await DbContext.UpdatePropertiesAsync(element, command, UserAccessor);
                    }
                }
            }
            else
            {
                var element = foundElement.FirstOrDefault();
                if (element != null)
                {
                    orderIdReturn = element.OrderId;
                    var command = new BaseUpDownCommand()
                    {
                        OrderId = orderId,
                    };
                    await DbContext.UpdatePropertiesAsync(element, command, UserAccessor);
                }
            }

            return orderIdReturn;
        }

        private ulong GetOrderIdForGuid<T>(IQueryable<T> ts, T model) where T : class, IEntity
        {
            ulong orderId = 0;
            var foundElement = GetElementByGuid(ts, model);
            if (foundElement != null && foundElement.FirstOrDefault() != null)
                orderId = foundElement.FirstOrDefault().OrderId;
            return orderId;
        }
        private IQueryable<T> GetElementByGuid<T>(IQueryable<T> ts, T model) where T : class, IEntity
        {
            return ts?.Where(u => u.Id == model.Id);
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
    }

}