using Masstransit.RabbitMq.Extensions;
using MassTransit;
using RequestResponsePattern.Contracts;
using System;
using System.Threading.Tasks;

namespace RequestResponsePattern.Consumer3
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
                    e.Handler<RequestA>(context =>
                    {
                        Console.WriteLine($"Receive Request: id={context.Message.Id}, {context.Message.DateTime}");

                        return context.RespondAsync<ResponseA>(new
                        {
                            Id = context.Message.Id,
                            DateTime = DateTime.Now,
                        });
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
