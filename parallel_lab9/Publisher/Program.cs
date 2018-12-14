using System;
using System.Text;
using RabbitMQ.Client;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer();
            server.CreateConnection();
            server.SendInf();
            server.Run();
            
            Console.ReadKey();
        }
    }
}
