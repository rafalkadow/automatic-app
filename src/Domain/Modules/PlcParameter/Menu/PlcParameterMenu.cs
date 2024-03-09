using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcParameter.Values;

namespace Domain.Modules.PlcParameter.Menu
{
    [Serializable]
    public class PlcParameterMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new PlcParameterValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}