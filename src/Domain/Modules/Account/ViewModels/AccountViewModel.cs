using Domain.Modules.Account.Values;
using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;

namespace Domain.Modules.Account.ViewModels
{
    [Serializable]
    public class AccountViewModel : ValueViewModel
    {
        #region Fields

        public string? AccountEmail { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? AccountPassword { get; set; }

        public string? RepeatPassword { get; set; }

        public int AccountTypeId { get; set; }
        public string? AccountTypeName { get; set; }

        #endregion Fields

        #region Constructors

        public AccountViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new AccountValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}