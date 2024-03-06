using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriverGroup.Consts;
using Domain.Modules.PlcDriverGroup.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.PlcDriverGroup.Values
{
    [Serializable]
    public class PlcDriverGroupValue : ValueBase, IValue
    {
        public PlcDriverGroupValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return PlcDriverGroupConsts.Url;
        }

        public override string ControllerName()
        {
            return PlcDriverGroupConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return PlcDriverGroupConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.PlcDriverGroup;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = PlcDriverGroupMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new category of PlcDriver has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The category of PlcDriver has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The category of PlcDriver could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The category of PlcDriver could not be updated";
        }
    }
}