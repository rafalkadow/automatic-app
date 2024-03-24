using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriverAlarm.Consts;
using Domain.Modules.PlcDriverAlarm.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.PlcDriverAlarm.Values
{
    [Serializable]
    public class PlcDriverAlarmValue : ValueBase, IValue
    {
        public PlcDriverAlarmValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return PlcDriverAlarmConsts.Url;
        }

        public override string ControllerName()
        {
            return PlcDriverAlarmConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return PlcDriverAlarmConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.PlcDriverAlarm;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = PlcDriverAlarmMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new plc driver alarm has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The plc driver alarm has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The plc driver alarm could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The plc driver alarm could not be updated";
        }
    }
}