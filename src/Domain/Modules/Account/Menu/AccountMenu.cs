using Domain.Modules.Account.Values;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;

namespace Domain.Modules.Account.Menu
{
    [Serializable]
    public class AccountMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new AccountValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}