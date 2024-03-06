using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.Error.Values;

namespace Domain.Modules.Error.ViewModels
{
    [Serializable]
    public class ErrorViewModel : ValueViewModel
    {
        #region Fields

        public string ErrorCode { get; set; }

        public string ErrorName { get; set; }

        public string ErrorDescription { get; set; }
        public string ErrorUrl { get; set; }
        public string UrlReturn { get; set; }

        #endregion Fields

        #region Constructors

        public ErrorViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new ErrorValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}