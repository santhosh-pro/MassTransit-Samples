using MassTransit;
using HandleExceptions.Contracts;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace HandleExceptions.Consumer1
{
    public class CommandAConsumer :
        IConsumer<CommandA>
    {
        public Task Consume(ConsumeContext<CommandA> context)
        {
            Console.WriteLine($"Receive Command: id={context.Message.Id}, {context.Message.DateTime}");
            throw new Exception("This is an exception when receiving.");
        }
    }
}
