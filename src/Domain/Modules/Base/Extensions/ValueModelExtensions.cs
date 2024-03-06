using Domain.Modules.Base.ViewModels;

namespace Domain.Modules.Base.Extensions
{
    public static class ValueModelExtensions
    {
        public static string FormListName(this ValueViewModel model)
        {
            var data = model.ControllerName() + "Form";
            return data;
        }

        public static string FormName(this ValueViewModel model, string actionAdd = "")
        {
            var data = model.ControllerName() + "Form" + actionAdd;
            return data;
        }

        public static string TableName(this ValueViewModel model)
        {
            var data = model.ControllerName() + "Table";
            return data;
        }
    }
}