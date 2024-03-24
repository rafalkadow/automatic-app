using System.ComponentModel;

namespace Domain.Modules.Base.Enums
{
	public enum MenuElementEnum
	{
		#region FrontEnd

		[Description("None")]
		None,

		SignIn,

		SignOut,

        #endregion FrontEnd

        Administration,

        AdministrationAccount,

        Account,

		Dictionaries,

        DictionariesGeneral,

        PlcDriverGroup,

        PlcDriver,

        Error,
        PlcParameter,
        PlcParameterHistory,
        DictionaryOfParameterInterval,
        DictionaryOfParameterCategory,
        PlcDriverAlarm,
    }
}