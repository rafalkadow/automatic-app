using Domain.Modules.Base.Commands;
using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcParameter.Commands
{
    [Serializable]
    public class DeletePlcParameterCommand : BaseActionCommand, IRequest<OperationResult>, ICommand
    {
    }
}