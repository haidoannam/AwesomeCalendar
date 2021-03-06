﻿using System.Threading.Tasks;
using AwesomeCalendar.Infrastructure.Interfaces.Contracts;
using AwesomeCalendar.Infrastructure.Interfaces.HandleResult;

namespace AwesomeCalendar.Infrastructure.Interfaces.Busses
{
    public interface ICommandBusExecutor
    {
        Task<IHandleResult> ExecuteAsync(ICommand command);
    }
}