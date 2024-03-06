using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Base.App;
using Domain.Modules.Interfaces;
using MediatR;
using Shared.Enums;

namespace Domain.Modules.Base.Models
{
	[Serializable]
	public class DefinitionModel : IDefinitionModel
    {
		#region Fields

		public OperationEnum OperationType { get; set; }

		public IValue ApplicationValue { get; set; }

        public IValidation ApplicationValidation { get; set; }

		public IUserAccessor UserAccessor { get; set; }
        #endregion Fields

        #region Constructors
        public DefinitionModel()
        {
                
        }
        public DefinitionModel(OperationEnum operationTypeValue, IUserAccessor userAccessor)
		{
			this.OperationType = operationTypeValue;
            this.UserAccessor = userAccessor;
        }

		#endregion Constructors
	}
}