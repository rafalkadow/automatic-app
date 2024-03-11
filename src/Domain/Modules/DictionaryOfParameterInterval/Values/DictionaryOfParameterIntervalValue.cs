using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.DictionaryOfParameterInterval.Consts;
using Domain.Modules.DictionaryOfParameterInterval.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.DictionaryOfParameterInterval.Values
{
    [Serializable]
    public class DictionaryOfParameterIntervalValue : ValueBase, IValue
    {
        public DictionaryOfParameterIntervalValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return DictionaryOfParameterIntervalConsts.Url;
        }

        public override string ControllerName()
        {
            return DictionaryOfParameterIntervalConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return DictionaryOfParameterIntervalConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.DictionaryOfParameterInterval;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = DictionaryOfParameterIntervalMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new DictionaryOfParameterInterval has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The DictionaryOfParameterInterval has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The DictionaryOfParameterInterval could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The DictionaryOfParameterInterval could not be updated";
        }
    }
}