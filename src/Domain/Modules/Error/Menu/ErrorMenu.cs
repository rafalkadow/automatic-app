using Domain.Modules.Base.Defaults;
using Domain.Modules.Base.Menu;
using Domain.Modules.Base.ViewModels;
using Shared.Web;

namespace Domain.Modules.Error.Menu
{
    [Serializable]
    public class ErrorMenu
    {
        public static MenuElement MenuToObject(ValueViewModel value)
        {
            var menu = new MenuElement
            {
                //MainMenuTitle = value.ApplicationValueClass().MenuPageTitle(),
                MainMenuUrl = MyHttpContext.AppBaseUrl + "/" + value.ControllerName(),

                //SubMenuBackButtonLabel = value.ApplicationValueClass().SubMenuBackButtonLabel(),
                //SubMenuBackButtonName = BaseDefault.SubMenuBackButtonName,
                //SubMenuSaveButtonLabel = value.ApplicationValueClass().SubMenuSaveButtonLabel(),
                //SubMenuSaveButtonName = BaseDefault.SubMenuSaveButtonName,
                //SubMenuSaveAndBackButtonLabel = value.ApplicationValueClass().SubMenuSaveAndBackButtonLabel(),
                SubMenuSaveAndBackButtonName = BaseDefault.SubMenuSaveAndBackButtonName,
                BackToListPage = BaseDefault.BackToListPage,
            };
            return menu;
        }
    }
}