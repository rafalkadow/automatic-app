﻿using MediatR;
using Shared.Interfaces;
using Shared.Models;

namespace Domain.Modules.PlcDriverAlarm.Commands
{
    [Serializable]
    public class CreatePlcDriverAlarmCommand : BasePlcDriverAlarmCommand, ICommand, IRequest<OperationResult>
    {
    }
}