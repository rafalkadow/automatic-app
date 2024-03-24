using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriverAlarm.Values;

namespace Domain.Modules.PlcDriverAlarm.Menu
{
    [Serializable]
    public class PlcDriverAlarmMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new PlcDriverAlarmValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}