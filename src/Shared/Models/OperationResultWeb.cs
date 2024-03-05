using Newtonsoft.Json;
using Shared.Interfaces;

namespace Shared.Models
{
	[Serializable]
	public class OperationResultWeb
	{
        #region Fields
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("operationType")]
        public string OperationType { get; set; }

        [JsonProperty("entityId")]
        public Guid? EntityId { get; set; }

        [JsonProperty("entity")]
        public IEntity Entity { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("messages")]
        public Dictionary<string, string> Messages { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
        #endregion Fields

        #region Ctors
        public OperationResultWeb()
		{
		}
        #endregion Ctors
    }
}