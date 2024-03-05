using Shared.Interfaces;
using Shared.Enums;
using FluentValidation.Results;
using Shared.Validation;
using Shared.Attributes;

namespace Shared.Models
{
    [Serializable]
    public class OperationResult
    {
        [SwaggerIgnore]
        public Guid? EntityId { get; set; }
        [SwaggerIgnore]
        public IEntity entity { get; set; }
		public string Message { get; set; }

        public string ErrorMessage { get; set; }

		public bool OperationStatus { get; set; } = true;

		public IEnumerable<ErrorMessage> Errors { get; private set; }
		public OperationEnum Operation { get; set; }

		public string GuidRecord { get; set; }

		public OperationResult(bool operationStatus)
		{
            OperationStatus = operationStatus;
		}
        public OperationResult(bool operationStatus, OperationEnum operation)
        {
            OperationStatus = operationStatus;
            this.Operation = operation;
        }
        public OperationResult(bool operationStatus, string errorMessage = "", OperationEnum Operation = OperationEnum.None)
		{
			this.OperationStatus = operationStatus;
			this.ErrorMessage = errorMessage;
			this.Operation = Operation;
		}

		public OperationResult(IEntity entity, OperationEnum operation)
		{
			this.entity = entity;
			this.EntityId = entity.Id;
			this.OperationStatus = true;
			this.GuidRecord = entity.Id.ToString();
			this.Operation = operation;
		}

        public OperationResult(Guid entityId)
        {
            this.EntityId = entityId;
            this.OperationStatus = true;
            this.GuidRecord = entityId.ToString();
        }

        public void FailureAdd(IList<ValidationFailure> validationFailures)
		{
			OperationStatus = false;
			Errors = validationFailures.Select(v => new ErrorMessage()
			{
				PropertyName = v.PropertyName,
				Message = v.ErrorMessage
			});
		}
	}
}