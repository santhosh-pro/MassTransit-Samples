using Masstransit.RabbitMq.Extensions;
using MassTransit;
using HandleExceptions.Contracts;
using System;
using System.Threading.Tasks;

namespace HandleExceptions.Consumer3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Consumer 3";

            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, Constants.QueueB, e =>
                {
                    e.Handler<CommandA>(context =>
                    {
                        Console.WriteLine($"Receive Command: id={context.Message.Id}, {context.Message.DateTime}");
                        return Task.CompletedTask;
                    });
                });
            });

            await bus.StartAsync();

            Console.WriteLine($"Listening ({Constants.QueueB})... Press enter to exit.");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
