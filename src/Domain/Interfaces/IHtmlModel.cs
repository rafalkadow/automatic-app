using Domain.Modules.Base.Menu;

namespace Domain.Interfaces
{
    public interface IHtmlModel
    {
        public string ControllerName();

        public MenuElement DataMenu();
    }
}