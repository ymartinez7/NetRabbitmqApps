using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var _factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "ymartinez7",
    Password = "y18010611m"
};

using (var connection = _factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare("TestQueue", false, false, false, null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.Span;
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine("Mesaje recibido {0}", message);
        };

        channel.BasicConsume("TestQueue", true, consumer);

        Console.WriteLine("Presiona [enter] para salir del consumer");
        Console.ReadLine();
    }
}