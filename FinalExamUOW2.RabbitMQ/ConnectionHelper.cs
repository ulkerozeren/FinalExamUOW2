using RabbitMQ.Client;

namespace FinalExamUOW2.RabbitMQ
{
    public class ConnectionHelper
    {
        public IConnection Connection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }
}
