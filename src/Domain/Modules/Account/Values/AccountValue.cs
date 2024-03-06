using Domain.Modules.Account.Consts;
using Domain.Modules.Account.Menu;
using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.Interfaces;

namespace Domain.Modules.Account.Values
{
    [Serializable]
    public class AccountValue : ValueBase, IValue
    {
        public AccountValue(IDefinitionModel definitionModel)
            : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return AccountConsts.Url;
        }

        public override string ControllerName()
        {
            return AccountConsts.ControllerName;
        }
        public override string ModuleTitle()
        {
            return AccountConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.Account;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = AccountMenu.MenuToObject(valueModel);
            return menu;
        }

        public override string SuccessMessageTitle()
        {
            return "A new account has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The account has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The application account could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The application account could not be updated";
        }
    }
}