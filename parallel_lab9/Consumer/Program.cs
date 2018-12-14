using System;
using System.Data.SqlClient;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                Protocol = Protocols.AMQP_0_9_1,
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.BasicQos(0, 1, false);

                channel.ExchangeDeclare("sample-ex", ExchangeType.Direct, true, false, null);
                channel.QueueDeclare("sample-queue", true, false, false, null);
                channel.QueueBind("sample-queue", "sample-ex", "optional-routing-key");

                BDConnect database = new BDConnect();

                using (var subscription = new Subscription(channel, "sample-queue", false))
                {
                    Console.WriteLine("Waiting for messages...");
                    var encoding = new UTF8Encoding();
                    while (channel.IsOpen)
                    {
                        BasicDeliverEventArgs eventArgs;
                        var success = subscription.Next(2000, out eventArgs);
                        if (success == false) continue;
                        var msgBytes = eventArgs.Body;
                        string message = encoding.GetString(msgBytes);
                        string[] elements = message.Split(' ');
                        
                        database.AddToBD(elements);
                        
                        foreach (string s in elements)
                        {
                            Console.WriteLine(s);
                        }
                        
                        channel.BasicAck(eventArgs.DeliveryTag, false);
                    }
                }
            }
        }
    }
}
