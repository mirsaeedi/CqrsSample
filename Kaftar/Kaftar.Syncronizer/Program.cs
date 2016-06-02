using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace Kaftar.Syncronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
                var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(body));
                (ch as IModel).BasicAck(ea.DeliveryTag, false);
            };
            String consumerTag = channel.BasicConsume("hello", false, consumer);

            Console.ReadLine();

        }
    }
}
