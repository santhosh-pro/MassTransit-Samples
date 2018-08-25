using Masstransit.RabbitMq.Extensions;
using MassTransit;
using PublishSubscribePattern.Contracts;
using System;
using System.Threading.Tasks;

namespace PublishSubscribePattern.Consumer3
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
                    e.Handler<EventA>(context =>
                    {
                        Console.WriteLine($"Receive Event: id={context.Message.Id}, {context.Message.DateTime}");

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
