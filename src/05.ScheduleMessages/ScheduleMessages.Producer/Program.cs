using Masstransit.RabbitMq.Extensions;
using MassTransit;
using ScheduleMessages.Contracts;
using System;
using System.Threading.Tasks;

namespace ScheduleMessages.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Producer";

            Console.WriteLine("Press 'Enter' to send a message. To exit, Ctrl + C");

            var bus = BusCreator.CreateBus((cfg, host) =>
            {
                cfg.UseInMemoryScheduler();

                cfg.ReceiveEndpoint(host, $"{Constants.QueueA}_error", e =>
                {
                    e.Consumer<WantAllFaultsGimmeThem>();
                    e.Consumer<CommandAFaultConsumer>();
                });
            });

            await bus.StartAsync();

            var sendToUri = new Uri($"{Constants.RabbitMqUri}{Constants.QueueA}");

            while (Console.ReadLine() != null)
            {
                var command = new
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Now
                };
                await bus.ScheduleSend<CommandA>(sendToUri, DateTime.Now.AddMinutes(1), command);

                Console.WriteLine($"Send Command: id={command.Id}, {command.DateTime} -> {DateTime.Now.AddMinutes(1)}");
            }

            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
