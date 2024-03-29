using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcDriverAlarm.Values;
using Domain.Modules.PlcParameter.Enum;
using Domain.Modules.PlcParameter.Models;

namespace Domain.Modules.PlcDriverAlarm.ViewModels
{
    public class PlcDriverAlarmViewModel : ValueViewModel
    {
        #region Fields
        public Guid PlcDriverId { get; set; }
        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public AlarmTypeEnum AlarmType { get; set; }

        public Guid TriggerParameterId { get; set; }
        public virtual PlcParameterModel TriggerParameter { get; set; }
        public Guid ResetParameterId { get; set; }
        public virtual PlcParameterModel ResetParameter { get; set; }

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