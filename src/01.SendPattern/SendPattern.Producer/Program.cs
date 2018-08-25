using Masstransit.RabbitMq.Extensions;
using SendPattern.Contracts;
using System;
using System.Threading.Tasks;

namespace SendPattern.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Producer";

            Console.WriteLine("Press 'Enter' to send a message. To exit, Ctrl + C");

            var bus = BusCreator.CreateBus();
            await bus.StartAsync();

            var sendToUri = new Uri($"{Constants.RabbitMqUri}{Constants.QueueA}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            while (Console.ReadLine() != null)
            {            
                var command = new
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Now
                };
                await endPoint.Send<CommandA>(command);

                Console.WriteLine($"Send Command: id={command.Id}, {command.DateTime}");
            }

            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
