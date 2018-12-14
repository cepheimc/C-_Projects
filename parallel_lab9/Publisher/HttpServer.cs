using System.Net;
using System.Text;
using Red;
using System.Xml.Serialization;
using RabbitMQ.Client;
using System.IO;
using Red.Extensions;

namespace Publisher
{
    class HttpServer
    {
        private  RedHttpServer server;
        private ConnectionFactory connectionFactory;
        private Beers beer;

        public void SendInf()
        {
            var server = new RedHttpServer(8000);

            server.Post("/write", async (req, res) =>
            {
                var bodyTask = req.ParseBodyAsync<string>();
                var body = bodyTask.Result;
                Serializetion(body);

                var msg = "";

                using (var connection = connectionFactory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("sample-ex", ExchangeType.Direct, true, false, null);
                    channel.QueueDeclare("sample-queue", true, false, false, null);
                    channel.QueueBind("sample-queue", "sample-ex", "optional-routing-key");
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;

                    var encoding = new UTF8Encoding();
                    foreach (Beer p in beer.beers)
                    {
                        msg = p.ID + " " + p.Name + " " + p.Type + " " + p.Ai + " " + p.Manufacture + " " +
                              p.Ingredient.ToString() + " " + p.Char.ToString();
                        var msgBytes = encoding.GetBytes(msg);
                        channel.BasicPublish("sample-ex", "optional-routing-key", null, msgBytes);
                    }

                    channel.Close();
                }

                await res.SendStatus(HttpStatusCode.OK);
            });
            this.server = server;
        }

        public async void Run()
        {
            await this.server.RunAsync();
        }

        public void CreateConnection()
        {
            connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
                Protocol = Protocols.AMQP_0_9_1,
            };

        }

        public void Serializetion(string body)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Beers));
            beer = new Beers();
            using (StringReader fs = new StringReader(body))
            {
                beer = (Beers)formatter.Deserialize(fs);
            }
        }
    }
}
