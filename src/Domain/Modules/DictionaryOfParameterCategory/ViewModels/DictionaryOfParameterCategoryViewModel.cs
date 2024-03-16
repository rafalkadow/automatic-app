using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.DictionaryOfParameterCategory.Values;

namespace Domain.Modules.DictionaryOfParameterCategory.ViewModels
{
    public class DictionaryOfParameterCategoryViewModel : ValueViewModel
    {
        #region Fields
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Value { get; set; }

        #endregion Fields

        #region Constructors

        public DictionaryOfParameterCategoryViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new DictionaryOfParameterCategoryValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}