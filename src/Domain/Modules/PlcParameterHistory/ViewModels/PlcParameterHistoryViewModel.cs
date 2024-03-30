using Domain.Modules.Base.Models;
using Domain.Modules.Base.Validations;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.PlcParameter.Models;
using Domain.Modules.PlcParameterHistory.Values;

namespace Domain.Modules.PlcParameterHistory.ViewModels
{
    public class PlcParameterHistoryViewModel : ValueViewModel
    {
        #region Fields
        public Guid PlcParameterId { get; set; }

        public virtual PlcParameterModel PlcParameter { get; set; }
        public int Value { get; set; }
        public DateTime DateAddUTC { get; set; }

        #endregion Fields

        #region Constructors

        public PlcParameterHistoryViewModel(IDefinitionModel model)
             : base(ChooseOperationType(model))
        {
            ViewName = ControllerNameWithOperation();
        }

        #endregion Constructors

        #region ChooseOperationType

        public static IDefinitionModel ChooseOperationType(IDefinitionModel model)
        {
            var value = new PlcParameterHistoryValue(model);
            var validation = new ValidationBase(model);
            model.ApplicationValue = value;
            model.ApplicationValidation = validation;
            return model;
        }

        #endregion ChooseOperationType
    }
}