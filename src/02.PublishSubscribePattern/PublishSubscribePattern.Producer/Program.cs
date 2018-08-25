using Masstransit.RabbitMq.Extensions;
using PublishSubscribePattern.Contracts;
using System;
using System.Threading.Tasks;

namespace PublishSubscribePattern.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Producer";

            Console.WriteLine("Press 'Enter' to send a message. To exit, Ctrl + C");

            var bus = BusCreator.CreateBus();
            await bus.StartAsync();

            while (Console.ReadLine() != null)
            {
                var command = new
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Now
                };
                await bus.Publish<EventA>(command);

                Console.WriteLine($"Publish Event: id={command.Id}, {command.DateTime}");
            }

            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
