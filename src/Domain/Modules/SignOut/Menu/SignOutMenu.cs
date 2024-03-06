using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.SignOut.Values;

namespace Domain.Modules.SignOut.Menu
{
    [Serializable]
    public class SignOutMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new SignOutValue(valueModel.Definition);
            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}