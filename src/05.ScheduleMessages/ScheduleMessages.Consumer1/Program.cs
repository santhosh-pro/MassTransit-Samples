using Masstransit.RabbitMq.Extensions;
using MassTransit;
using ScheduleMessages.Contracts;
using System;
using System.Threading.Tasks;
using GreenPipes;
using System.Linq;

namespace ScheduleMessages.Consumer1
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
                    e.UseRetry(r => r.Immediate(5));

                    e.Consumer<CommandAConsumer>();
                });
            });

            await bus.StartAsync();

            Console.WriteLine($"Listening ({Constants.QueueA})... Press enter to exit.");
            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
