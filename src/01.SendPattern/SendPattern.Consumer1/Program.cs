using Masstransit.RabbitMq.Extensions;
using MassTransit;
using SendPattern.Contracts;
using System;
using System.Threading.Tasks;

namespace SendPattern.Consumer1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Consumer 1";

            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, Constants.QueueA, e =>
                {
                    e.Handler<CommandA>(context =>
                    {
                        Console.WriteLine($"Receive Command: id={context.Message.Id}, {context.Message.DateTime}");

                        return Task.CompletedTask;
                    });
                });
            });

            await bus.StartAsync();

            Console.WriteLine($"Listening ({Constants.QueueA})... Press enter to exit.");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
