using RabbitMQ.Client;
using System.Text;

var _factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName= "ymartinez7",
    Password = "y18010611m"
};

using (var connection = _factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare("TestQueue", false, false, false, null);

        var message = "Bienvenido al proyecto RabbitMQ y .NET";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(String.Empty, "TestQueue", null, body);

        Console.WriteLine("El mensaje fue enviado {0}", message);
    }
}

Console.WriteLine("Presiona [enter] para salir de la aplicación");
Console.ReadLine();