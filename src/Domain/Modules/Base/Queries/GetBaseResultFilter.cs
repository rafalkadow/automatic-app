using Domain.Modules.Base.Enums;
using Shared.Attributes;
using Shared.Enums;
using System.Text.Json.Serialization;

namespace Domain.Modules.Base.Queries
{
    [Serializable]
	public class GetBaseResultFilter
	{
		public GetBaseResultFilter()
		{
		}

		public GetBaseResultFilter(Guid Id)
		{
			this.Id = Id;
		}

		public Guid Id { set; get; }
        [JsonIgnore]
        public int DisplayStart { get; set; }
        [JsonIgnore]
        public bool DisplayLengthActive { get; set; } = true;
        [JsonIgnore]
        public int DisplayLength { get; set; } = 100;
        [JsonIgnore]
        public int Echo { get; set; }
        [JsonIgnore]
        public int TotalRecords { get; set; }
        [JsonIgnore]
        public OrderSortEnum OrderSortValue { get; set; } = OrderSortEnum.Desc;

		
		public Guid? CreatedUserId { get; set; }
		public string CreatedUserName { get; set; }
        [SwaggerIgnore]
        public DateTime? CreatedFrom { get; set; }
        [SwaggerIgnore]
        public DateTime? CreatedTo { get; set; }

		public DateTime? CreatedOnDateTimeUTC { get; set; }

		public Guid? ModifiedUserId { get; set; }

		public string ModifiedUserName { get; set; }

		public DateTime? ModifiedOnDateTimeUTC { get; set; }
        [JsonIgnore]
        public RecordStatusEnum RecordStatus { get; set; } = RecordStatusEnum.AllRecords;
        [SwaggerIgnore]
        public bool CaseSensitiveComparison { get; set; }
		public long OrderId { get; set; }
	}
}