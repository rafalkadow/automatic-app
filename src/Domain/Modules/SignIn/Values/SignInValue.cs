using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.Interfaces;
using Domain.Modules.SignIn.Consts;
using Domain.Modules.SignIn.Menu;

namespace Domain.Modules.SignIn.Values
{
    [Serializable]
    public class SignInValue : ValueBase, IValue
    {
        public SignInValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return SignInConsts.Url;
        }

        public override string ControllerName()
        {
            return SignInConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return SignInConsts.Title;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = SignInMenu.MenuToObject(valueModel);
            return menu;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.SignIn;
        }
        public override string SuccessMessageTitle()
        {
            return "The user has logged in successfully";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The user has logged in successfully";
        }
        public override string ErrorMessageTitle()
        {
            return "The user could not be logged in";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The user could not be logged in";
        }
    }
}