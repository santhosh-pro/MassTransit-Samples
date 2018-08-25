using Masstransit.RabbitMq.Extensions;
using MassTransit;
using RequestResponsePattern.Contracts;
using System;
using System.Threading.Tasks;

namespace RequestResponsePattern.Producer
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
                var request = new
                {
                    Id = Guid.NewGuid(),
                    DateTime = DateTime.Now
                };

                var response = await bus.Request<RequestA, ResponseA>(
                    new Uri($"{Constants.RabbitMqUri}{Constants.QueueA}"),
                    request);

                Console.WriteLine($"Send Request: id={request.Id}, {request.DateTime}");
                Console.WriteLine($"Receive Response: id={response.Message.Id}, {response.Message.DateTime}");
            }

            Console.ReadLine();

            await bus.StopAsync();
        }
    }
}
