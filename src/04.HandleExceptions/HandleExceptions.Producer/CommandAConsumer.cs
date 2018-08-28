using MassTransit;
using HandleExceptions.Contracts;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace HandleExceptions.Producer
{
    public class CommandAFaultConsumer :
        IConsumer<Fault<CommandA>>
    {
        public Task Consume(ConsumeContext<Fault<CommandA>> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"FAULT<CommandA>: {context.Message.Exceptions.First().Message}.");
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }

    public class WantAllFaultsGimmeThem : IConsumer<Fault>
    {
        public Task Consume(ConsumeContext<Fault> context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"FAULT<CommandA>: {context.Message.Exceptions.First().Message}.");
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
