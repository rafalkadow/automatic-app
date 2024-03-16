using Domain.Modules.Base.Queries;

namespace Domain.Modules.DictionaryOfParameterCategory.Queries
{
    [Serializable]
	public class GetDictionaryOfParameterCategoryBase : GetBaseResultFilter
	{
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Value { get; set; }
    }
}