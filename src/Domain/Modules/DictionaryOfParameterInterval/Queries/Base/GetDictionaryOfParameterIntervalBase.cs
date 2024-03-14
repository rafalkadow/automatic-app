using Domain.Modules.Base.Queries;

namespace Domain.Modules.DictionaryOfParameterInterval.Queries
{
    [Serializable]
	public class GetDictionaryOfParameterIntervalBase : GetBaseResultFilter
	{
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Value { get; set; }
    }
}