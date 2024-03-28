using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.PlcParameter.Enum;
using Domain.Modules.PlcParameter.Values;

namespace Domain.Modules.PlcParameter.ViewModels
{
    public class PlcParameterViewModel : ValueViewModel
    {
        #region Fields
        public Guid PlcDriverId { get; set; }
        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Address { get; set; }
        public AccessModeTypeEnum AccessModeType { get; set; }
        public ModbusTypeEnum ModbusTypeEnum { get; set; }
        public ParameterTypeEnum ParameterType { get; set; }
        public YesNoEnum ModbusVisibility { get; set; }
        public YesNoEnum RecordToDatabase { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }

        #endregion Fields

        #region Constructors

        public PlcParameterViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new PlcParameterValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}