namespace Domain.Modules.Base.Consts
{
	[Serializable]
	public class BaseValidationConsts
	{
		public const string FluentValidationErrorCustom = "FluentValidationErrorCustom";
		public const string DependencyDeleteError = "DependencyDeleteError";
		public const string DependencyDeleteErrorStr = "Nie udało się usunąć rekordu/rekordów. Istnieje zależność z innymi funkcjonalnościami/tabelami";
	}
}