using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriver.Consts;
using Domain.Modules.PlcDriver.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.PlcDriver.Values
{
    [Serializable]
    public class PlcDriverValue : ValueBase, IValue
    {
        public PlcDriverValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return PlcDriverConsts.Url;
        }

        public override string ControllerName()
        {
            return PlcDriverConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return PlcDriverConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.PlcDriver;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = PlcDriverMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new PlcDriver has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The PlcDriver has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The PlcDriver could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The PlcDriver could not be updated";
        }
    }
}