using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcParameterHistory.Values;

namespace Domain.Modules.PlcParameterHistory.Menu
{
    [Serializable]
    public class PlcParameterHistoryMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new PlcParameterHistoryValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}