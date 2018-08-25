using Masstransit.RabbitMq.Extensions;
using MassTransit;
using PublishSubscribePattern.Contracts;
using System;
using System.Threading.Tasks;

namespace PublishSubscribePattern.Consumer1
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
                    e.Handler<EventA>(context =>
                    {
                        Console.WriteLine($"Receive Event: id={context.Message.Id}, {context.Message.DateTime}");

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
