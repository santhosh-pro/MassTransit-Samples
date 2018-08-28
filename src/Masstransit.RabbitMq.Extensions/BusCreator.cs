using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace Masstransit.RabbitMq.Extensions
{
    public static class BusCreator
    {
        public static IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(Constants.RabbitMqUri), hst =>
                {
                    hst.Username(Constants.UserName);
                    hst.Password(Constants.Password);
                });

                registrationAction?.Invoke(cfg, host);
            });
        }
    }

    public class Constants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "guest";
        public const string Password = "guest";

        public const string QueueA = "queue-a";
        public const string QueueB = "queue-b";
    }
}
