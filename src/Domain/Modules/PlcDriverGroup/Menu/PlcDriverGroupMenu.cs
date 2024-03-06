using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriverGroup.Values;

namespace Domain.Modules.PlcDriverGroup.Menu
{
    [Serializable]
    public class PlcDriverGroupMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new PlcDriverGroupValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}