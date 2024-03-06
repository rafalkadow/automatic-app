using Domain.Modules.Base.Menu;
using Domain.Modules.Base.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Modules.Base.ViewModels
{
    [Serializable]
    public class ValueViewModel : HtmlViewModel
    {
        #region Fields

        [NotMapped]
        public string ViewName { get; set; }

        [NotMapped]
        public string? ReturnUrl { get; set; }

		#endregion Fields

		#region Constructors

		public ValueViewModel(IDefinitionModel model)
            : base(model)
        {
        }

        #endregion Constructors

        public MenuElement DataMenu()
        {
            var data = ApplicationValueClass().DataMenu(this);
            data.Id = Id;
            return data;
        }
    }
}