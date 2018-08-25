using Masstransit.RabbitMq.Extensions;
using MassTransit;
using RequestResponsePattern.Contracts;
using System;
using System.Threading.Tasks;

namespace RequestResponsePattern.Consumer2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Consumer 2";

            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, Constants.QueueA, e =>
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

            Console.WriteLine($"Listening ({Constants.QueueA})... Press enter to exit.");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
