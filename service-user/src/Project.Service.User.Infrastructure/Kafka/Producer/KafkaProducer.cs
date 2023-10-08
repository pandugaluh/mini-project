using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Service.User.Application.Options;

namespace Project.Service.User.Infrastructure.Kafka.Producer
{
    public class KafkaProducer : IKafkaProducer
    {
        private KafkaSettings kafkaSettings;
        protected ILogger _logger { get; set; }

        public KafkaProducer(IOptions<KafkaSettings> options)
        {
            kafkaSettings = options.Value;
        }

        public async Task<bool> SendMessage(string topic, string key, string value)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaSettings.BootcampServer,

                //TransactionTimeoutMs = 5000,
                //StatisticsIntervalMs = 5000,
                //MessageTimeoutMs = 5000,
                //RequestTimeoutMs = 5000,
                //SocketTimeoutMs = 5000,

                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.ScramSha512,

                SaslUsername = kafkaSettings.SaslUsername,
                SaslPassword = kafkaSettings.SaslPassword

            };

            var producer = new ProducerBuilder<string, string>(config).Build();

            try
            {
                var result = await producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value });

                if (result.Status == Confluent.Kafka.PersistenceStatus.Persisted)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Kafka in Producer Error : {message} stack trace {trace}", ex.Message.ToString(), ex.StackTrace.ToString());
            }

            return false;
        }
    }
}
