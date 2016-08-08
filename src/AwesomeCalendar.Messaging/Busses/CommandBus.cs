﻿using System.Threading.Tasks;
using AwesomeCalendar.Infrastructure.Interfaces.Busses;
using AwesomeCalendar.Infrastructure.Interfaces.Contracts;
using AwesomeCalendar.Infrastructure.Interfaces.HandleResult;
using EasyNetQ;

namespace AwesomeCalendar.Messaging.Busses
{
    public class CommandBus : ICommandBus
    {
        IBus Bus { get; }
        ICommandBusExecutor CommandBusExecutor { get; }

        public CommandBus(ICommandBusExecutor commandBusExecutor)
        {
            CommandBusExecutor = commandBusExecutor;

            Bus = RabbitHutch.CreateBus("host=localhost");
            Bus.Respond<ICommand, IHandleResult>(commandBusExecutor.Execute);
        }

        public IHandleResult Send<TCommand>(TCommand command) where TCommand : class, ICommand =>
            Bus.Request<ICommand, IHandleResult>(command);


        public async Task<IHandleResult> SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand =>
            await Bus.RequestAsync<ICommand, IHandleResult>(command);
    }
}
