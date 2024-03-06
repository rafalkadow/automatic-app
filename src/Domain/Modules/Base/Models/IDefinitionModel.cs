using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Interfaces;
using Shared.Enums;

namespace Domain.Modules.Base.Models
{
	public interface IDefinitionModel
    {
        #region Fields

        public OperationEnum OperationType { get; set; }
        public IValue ApplicationValue { get; set; }
        public IValidation ApplicationValidation { get; set; }
        public IUserAccessor UserAccessor { get; set; }

        #endregion Fields

    }
}