namespace Project.Service.User.Infrastructure.Kafka.Producer
{
    public interface IKafkaProducer
    {
        Task<bool> SendMessage(string topic, string key, string value);
    }
}
