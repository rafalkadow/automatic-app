using System.ComponentModel;

namespace Shared.Enums
{
	[Serializable]
	public enum OperationEnum
	{
		[Description("None")]
		None,

		[Description("Create")]
		Create,

		[Description("Update")]
		Update,

		[Description("Delete")]
		Delete,

		[Description("Up")]
		Up,

		[Description("Down")]
		Down,

		[Description("Active")]
		Active,

		[Description("InActive")]
		InActive,

		[Description("Archive")]
		Archive,

		[Description("First")]
		First,

		[Description("Last")]
		Last,

		[Description("Export")]
		Export,

		[Description("Import")]
		Import,

		[Description("View")]
		View,

		[Description("List")]
		List,

		[Description("Seed")]
		Seed,

        [Description("Job")]
        Job,
    }
}