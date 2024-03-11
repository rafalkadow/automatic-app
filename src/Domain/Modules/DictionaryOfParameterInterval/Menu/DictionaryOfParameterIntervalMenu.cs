using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.DictionaryOfParameterInterval.Values;

namespace Domain.Modules.DictionaryOfParameterInterval.Menu
{
    [Serializable]
    public class DictionaryOfParameterIntervalMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new DictionaryOfParameterIntervalValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}