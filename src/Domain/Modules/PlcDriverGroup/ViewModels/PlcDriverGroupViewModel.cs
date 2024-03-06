using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcDriverGroup.Values;

namespace Domain.Modules.PlcDriverGroup.ViewModels
{
    public class PlcDriverGroupViewModel : ValueViewModel
    {
        #region Fields
        public string? Name { get; set; }

        public string? Description { get; set; }

        #endregion Fields

        #region Constructors

        public PlcDriverGroupViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new PlcDriverGroupValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}