using Domain.Interfaces;
using Domain.Modules.Base.Commands;
using Shared.Enums;

namespace Domain.Modules.Base.Models
{
    [Serializable]
    public class OperationCommandModel
    {
        public OperationEnum Operation { get; set; }

        public string ControllerName { get; set; }
        public Guid Id { get; set; }

        public string WebRootPath { get; set; }
    }
}