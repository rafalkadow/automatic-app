using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.Error.Consts;
using Domain.Modules.Error.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.Error.Values
{
    [Serializable]
    public class ErrorValue : ValueBase, IValue
    {
        public ErrorValue(IDefinitionModel definitionModel)
            : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return ErrorConsts.Url;
        }

        public override string ControllerName()
        {
            return ErrorConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return ErrorConsts.Title;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = ErrorMenu.MenuToObject(valueModel);
            return menu;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.Error;
        }

        public override string SuccessMessageTitle()
        {
            return "";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "";
        }
        public override string ErrorMessageTitle()
        {
            return "";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "";
        }
    }
}