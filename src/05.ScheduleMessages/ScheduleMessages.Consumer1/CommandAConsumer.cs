using MassTransit;
using ScheduleMessages.Contracts;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ScheduleMessages.Consumer1
{
    public class CommandAConsumer :
        IConsumer<CommandA>
    {
        public Task Consume(ConsumeContext<CommandA> context)
        {
            Console.WriteLine($"{DateTime.Now:yyyy/MM/dd HH:mm:ss} - Receive Command: id={context.Message.Id}, {context.Message.DateTime}");
            return Task.CompletedTask;
        }
    }
}
