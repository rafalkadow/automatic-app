using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriverAlarm.Values;

namespace Domain.Modules.PlcDriverAlarm.ViewModels
{
    public class PlcDriverAlarmViewModel : ValueViewModel
    {
        #region Fields
        public string? Name { get; set; }

        public string? Description { get; set; }

        #endregion Fields

        #region Constructors

        public PlcDriverAlarmViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new PlcDriverAlarmValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}