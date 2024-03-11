using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriver.Models;
using Domain.Modules.DictionaryOfParameterInterval.Values;

namespace Domain.Modules.DictionaryOfParameterInterval.ViewModels
{
    public class DictionaryOfParameterIntervalViewModel : ValueViewModel
    {
        #region Fields
        public Guid PlcDriverId { get; set; }

        public virtual PlcDriverModel PlcDriver { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Type { get; set; }

        #endregion Fields

        #region Constructors

        public DictionaryOfParameterIntervalViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new DictionaryOfParameterIntervalValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}