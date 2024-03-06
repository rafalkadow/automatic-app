using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.Interfaces;
using Domain.Modules.SignOut.Consts;
using Domain.Modules.SignOut.Menu;
using Shared.Web;

namespace Domain.Modules.SignOut.Values
{
    [Serializable]
    public class SignOutValue : ValueBase, IValue
    {
        public SignOutValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return SignOutConsts.Url;
        }

        public override string ControllerName()
        {
            return SignOutConsts.ControllerName;
        }
        public override string ModuleTitle()
        {
            return SignOutConsts.Title;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = SignOutMenu.MenuToObject(valueModel);
            return menu;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.SignOut;
        }

        public override string SuccessMessageTitle()
        {
            return "The user has logged out successfully";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The user has logged out successfully";
        }
        public override string ErrorMessageTitle()
        {
            return "The user could not be logged out";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The user could not be logged out";
        }
    }
}