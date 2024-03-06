using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriver.Values;
using Domain.Modules.PlcDriverGroup.Models;

namespace Domain.Modules.PlcDriver.ViewModels
{
    public class PlcDriverViewModel : ValueViewModel
    {
        #region Fields
        public Guid PlcDriverGroupId { get; set; }

        public virtual PlcDriverGroupModel PlcDriverGroup { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? DeviceAddress { get; set; }
        public int DevicePort { get; set; }

        public int SlaveId { get; set; }

        public int TimeOut { get; set; }
        #endregion Fields

        #region Constructors

        public PlcDriverViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new PlcDriverValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}