using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.SignIn.Values;

namespace Domain.Modules.SignIn.Menu
{
    [Serializable]
    public class SignInMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new SignInValue(valueModel.Definition);
            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}