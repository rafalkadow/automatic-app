using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.ViewModels;
using Shared.Enums;

namespace Domain.Modules.Base.Values
{
	public abstract class ValueBase
    {
        public IDefinitionModel? Definition { get; set; }

        public OperationEnum OperationType { get; set; }

		public ValueBase(IDefinitionModel definitionModel)
        {
            this.Definition = definitionModel;
            this.OperationType = definitionModel.OperationType;
		}

        public int TimeoutValueAjax()
        {
            var data = 60000;
            return data;
        }
        public abstract string ModuleUrl();
        public abstract string ControllerName();
        public abstract string ModuleTitle();
        public abstract MenuElement DataMenu(ValueViewModel valueModel);
        public abstract MenuElementEnum SubMenuElementName();
        public abstract string SuccessMessageTitle();
        public abstract string SuccessMessageAnotherTitle();
        public abstract string ErrorMessageTitle();
        public abstract string ErrorMessageAnotherTitle();
    }
}