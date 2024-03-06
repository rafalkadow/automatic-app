using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.ViewModels;

namespace Domain.Modules.Interfaces
{
	public interface IValue
    {
		MenuElement DataMenu(ValueViewModel valueModel);
		string ControllerName();

        public IDefinitionModel? Definition { get; set; }

        string ModuleUrl();
        string ModuleTitle();
        MenuElementEnum SubMenuElementName();

        public abstract string SuccessMessageTitle();
        public abstract string SuccessMessageAnotherTitle();
        public abstract string ErrorMessageTitle();
        public abstract string ErrorMessageAnotherTitle();
    }
}