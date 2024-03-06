using Domain.Modules.Base.Defaults;
using Domain.Modules.Base.Enums;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.Interfaces;
using Shared.Enums;
using Shared.Web;

namespace Domain.Modules.Base.Menu
{
    [Serializable]
    public abstract class BaseMenu
    {
        public static string MainMenuUrlMethod(IValue value)
        {
            return MyHttpContext.AppBaseUrl + "/" + value.ControllerName() + "/";
        }

        public static string SubMenuUrlCreate(IValue value, ValueViewModel valueModel)
        {
            string url = string.Empty;
         
                url = MyHttpContext.AppBaseUrl + "/" + value.ModuleUrl() + "/" + OperationEnum.Create.ToString().ToLower();
           
            return url;
        }

        public static string SubMenuUrlUpdate(IValue value)
        {
            return MyHttpContext.AppBaseUrl + "/" + value.ModuleUrl() + "/" + OperationEnum.Update.ToString().ToLower() + "/";
        }

        public static MenuElement GetMenu(IValue value, ValueViewModel valueModel)
        {
            var menu = new MenuElement
            {
            
                SubMenuUrlCreate = SubMenuUrlCreate(value, valueModel),
                SubMenuUrlUpdate = SubMenuUrlUpdate(value),
                BackToListPage = BaseDefault.BackToListPage,
            };
            return menu;
        }
    }
}