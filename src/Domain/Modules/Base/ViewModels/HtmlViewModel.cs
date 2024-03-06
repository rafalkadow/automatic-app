using Domain.Modules.Base.Consts;
using Domain.Modules.Base.Enums;
using Domain.Modules.Base.Models;
using Domain.Modules.Interfaces;
using Shared.Enums;
using Shared.Extensions.EnumExtensions;
using Shared.Web;

namespace Domain.Modules.Base.ViewModels
{
    [Serializable]
    public class HtmlViewModel : BaseViewModel
    {
        #region Fields

        private OperationEnum operationEnum;

        public OperationEnum OperationTypeValue()
        {
            return operationEnum;
        }

        private string _appUrl;

        public string AppUrl()
        {
            return _appUrl;
        }

        private string _moduleUrl;

        public string ModuleUrl()
        {
            return _moduleUrl;
        }

        private string _controllerName;

        public string ControllerName()
        {
            return _controllerName;
        }

        private string _moduleTitle;

        public string ModuleTitle()
        {
            return _moduleTitle;
        }

        public string ControllerNameUrlWithOperation(string controllerName = "")
        {
            var returnValue = "/" + (string.IsNullOrEmpty(controllerName) ? ModuleUrl() : controllerName) + "/" + OperationTypeUpper() + "/";

            return returnValue;
        }
        public string ControllerNameUrlNew()
        {
            var returnValue = "/" + ModuleUrl() + "/" + OperationEnum.Create.GetDescription() + "/";
            return returnValue;
        }

        public string ControllerNameUrlUpdate()
        {
            var returnValue = "/" +  ModuleUrl() + "/" + OperationEnum.Update.GetDescription() + "/";
            return returnValue;
        }

        private IValue _IValue;
        public IValue ApplicationValueClass()
        {
            return _IValue;
        }

        public string JavascriptSource { get; set; }

        public MenuElementEnum SubMenuElementName { get; set; }

        private int TimeoutValueAjax { get; set; }

        public int TimeoutValueAjaxGet()
        {
            return TimeoutValueAjax;
        }

		public IDefinitionModel Definition { get; set; }

        public Guid UserGuid { get; set; }
        public string UserName { get; set; }

        #endregion Fields

        #region Constructors

        public HtmlViewModel(IDefinitionModel definitionModel)
            : base()
        {
			Definition = definitionModel;
			_IValue = definitionModel.ApplicationValue;
            _moduleUrl = _IValue.ModuleUrl();

            _controllerName = _IValue.ControllerName();
            _moduleTitle = _IValue.ModuleTitle();

            TimeoutValueAjax = 60000;
           
            JavascriptSource = MyHttpContext.AppBaseUrl + "/Areas/" + ControllerName() + "/Javascript/";
            operationEnum = definitionModel.OperationType;

            _appUrl = getUrlApp();

            if (definitionModel.UserAccessor != null)
            {
                UserGuid = definitionModel.UserAccessor.UserGuid;
                UserName = definitionModel.UserAccessor.UserName;
            }
            SubMenuElementName = _IValue.SubMenuElementName();
        }

        #endregion Constructors

        #region Methods

        private string getUrlApp()
        {
            string url = MyHttpContext.AppBaseUrl;

            return url;
        }

        public string GetAction(OperationEnum value)
        {
            return "/" + value + "/" + BaseConsts.Action;
        }

        public string ControllerNameUrl(string? controllerName = null)
        {
            var returnValue = "/" + (string.IsNullOrEmpty(controllerName) ? ModuleUrl() : controllerName);

            return returnValue;
        }

        public string ControllerNameWithOperation()
        {
            var returnValue = ControllerName() + OperationTypeUpper();
            return returnValue;
        }


        public string SignInLanguageSwitch(string url, string languageCode)
        {
            string returnValue;
            returnValue = MyHttpContext.AppBaseUrl;
            returnValue = returnValue + "/" + url;
            return returnValue;
        }

        public string ControllerNameUrlWithOperation(string controllerName, string operationType)
        {
            var returnValue = "/" + controllerName + "/" + operationType + "/";

            return returnValue;
        }

        public string OperationTypeUpper()
        {
            return OperationTypeValue().GetDescription();
        }

        #endregion Methods
    }
}