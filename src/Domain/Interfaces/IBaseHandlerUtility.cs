using Domain.Modules.Base.Models;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Interfaces
{
	public interface IBaseHandlerUtility
    {
        public Task<OperationResult> CommandActionAsync<T>(OperationCommandModel commandModel, Func<T, bool> condition = null) where T : class, IEntity;
    }
}