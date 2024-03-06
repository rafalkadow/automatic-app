using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.SignIn.Values;

namespace Domain.Modules.SignIn.ViewModels
{
    public class SignInViewModel : ValueViewModel
    {
        #region Fields

        public string SignInEmail { get; set; }

        public string SignInPassword { get; set; }

        public string SignInPasswordNew { get; set; }

        public string SignInPasswordRepeat { get; set; }
        
        public bool RememberData { get; set; }

        public bool LanguageRedirect { get; set; }

        public string LanguageCulture { get; set; }

        #endregion Fields

        #region Constructors

        public SignInViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new SignInValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}