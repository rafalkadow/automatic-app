using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcParameter.Consts;
using Domain.Modules.PlcParameter.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.PlcParameter.Values
{
    [Serializable]
    public class PlcParameterValue : ValueBase, IValue
    {
        public PlcParameterValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return PlcParameterConsts.Url;
        }

        public override string ControllerName()
        {
            return PlcParameterConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return PlcParameterConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.PlcParameter;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = PlcParameterMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new PlcParameter has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The PlcParameter has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The PlcParameter could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The PlcParameter could not be updated";
        }
    }
}