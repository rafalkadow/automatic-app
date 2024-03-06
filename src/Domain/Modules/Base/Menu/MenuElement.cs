using Domain.Modules.Base.Enums;

namespace Domain.Modules.Base.Menu
{
    [Serializable]
    public class MenuElement
    {
        #region Fields

        public string MainMenuUrl { get; set; }

        public string SubMenuUrlCreate { get; set; }

        public string SubMenuUrlUpdate { get; set; }

        public string SubMenuUrlItems { get; set; }

        public string SubMenuSaveAndBackButtonName { get; set; }
        public string BackToListPage { get; set; }


        public Guid Id { get; set; }

        #endregion Fields

        public string SubMenuUrlUpdateFunction(Guid Id)
        {
            string result = SubMenuUrlUpdate + Id;
            return result;
        }

        public string SubMenuUrlItemsFunction(Guid Id, DataGridEnum DataGridType, bool isIframe)
        {
            string result = SubMenuUrlItems + Id;
   
            return result;
        }

        #region Constructor

        public MenuElement()
        {
        }

        #endregion Constructor
    }
}