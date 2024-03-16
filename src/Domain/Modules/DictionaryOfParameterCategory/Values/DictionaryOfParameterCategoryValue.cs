using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.DictionaryOfParameterCategory.Consts;
using Domain.Modules.DictionaryOfParameterCategory.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.DictionaryOfParameterCategory.Values
{
    [Serializable]
    public class DictionaryOfParameterCategoryValue : ValueBase, IValue
    {
        public DictionaryOfParameterCategoryValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return DictionaryOfParameterCategoryConsts.Url;
        }

        public override string ControllerName()
        {
            return DictionaryOfParameterCategoryConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return DictionaryOfParameterCategoryConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.DictionaryOfParameterCategory;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = DictionaryOfParameterCategoryMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new DictionaryOfParameterCategory has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The DictionaryOfParameterCategory has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The DictionaryOfParameterCategory could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The DictionaryOfParameterCategory could not be updated";
        }
    }
}