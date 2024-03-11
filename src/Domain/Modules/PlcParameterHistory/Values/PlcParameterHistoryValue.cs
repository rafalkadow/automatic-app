using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Values;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcParameterHistory.Consts;
using Domain.Modules.PlcParameterHistory.Menu;
using Domain.Modules.Interfaces;

namespace Domain.Modules.PlcParameterHistory.Values
{
    [Serializable]
    public class PlcParameterHistoryValue : ValueBase, IValue
    {
        public PlcParameterHistoryValue(IDefinitionModel definitionModel)
           : base(definitionModel)
        {
        }

        public override string ModuleUrl()
        {
            return PlcParameterHistoryConsts.Url;
        }

        public override string ControllerName()
        {
            return PlcParameterHistoryConsts.ControllerName;
        }

        public override string ModuleTitle()
        {
            return PlcParameterHistoryConsts.Title;
        }

        public override MenuElementEnum SubMenuElementName()
        {
            return MenuElementEnum.PlcParameterHistory;
        }

        public override MenuElement DataMenu(ValueViewModel valueModel)
        {
            var menu = PlcParameterHistoryMenu.MenuToObject(valueModel);
            return menu;
        }
        public override string SuccessMessageTitle()
        {
            return "A new PlcParameterHistory has been added";
        }
        public override string SuccessMessageAnotherTitle()
        {
            return "The PlcParameterHistory has been updated";
        }
        public override string ErrorMessageTitle()
        {
            return "The PlcParameterHistory could not be added";
        }
        public override string ErrorMessageAnotherTitle()
        {
            return "The PlcParameterHistory could not be updated";
        }
    }
}