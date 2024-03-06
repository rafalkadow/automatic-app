using Domain.Modules.Account.Menu;
using Domain.Modules.Base.ViewModels;
using Domain.Modules.SignIn.Menu;
using Domain.Modules.SignOut.Menu;

namespace Domain.Modules.Base.Menu
{
	[Serializable]
	public class UrlData
	{
		#region Fields

		public MenuElement SignInMenuElement { get; set; }
		public MenuElement SignOutMenuElement { get; set; }
		public MenuElement AccountMenuElement { get; set; }

		//ToAddData

		#endregion Fields

		#region Constructor

		public UrlData(ValueViewModel model)
		{
			SignOutMenuElement = SignOutMenu.MenuToObject(model);
			SignInMenuElement = SignInMenu.MenuToObject(model);

			AccountMenuElement = AccountMenu.MenuToObject(model);
		}

		#endregion Constructor
	}
}