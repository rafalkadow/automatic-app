using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.DictionaryOfParameterCategory.Values;

namespace Domain.Modules.DictionaryOfParameterCategory.Menu
{
    [Serializable]
    public class DictionaryOfParameterCategoryMenu : BaseMenu
    {
        public static MenuElement MenuToObject(ValueViewModel valueModel)
        {
            var value = new DictionaryOfParameterCategoryValue(valueModel.Definition);

            var menu = GetMenu(value, valueModel);
            return menu;
        }
    }
}