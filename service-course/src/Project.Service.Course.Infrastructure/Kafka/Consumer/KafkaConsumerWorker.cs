using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Service.Course.Application.Interfaces.Services;
using Project.Service.Course.Application.Options;

namespace Project.Service.Course.Infrastructure.Kafka.Consumer
{
    public class KafkaConsumerWorker : BackgroundService
    {
        private KafkaSettings kafkaSettings;
        private readonly ConsumerConfig _consumerConfig;
        private readonly IServiceScopeFactory _scopeFactory;

        protected ILogger _logger { get; set; }

        public KafkaConsumerWorker(IOptions<KafkaSettings> options, IServiceScopeFactory scopeFactory)
        {
            kafkaSettings = options.Value;
            _scopeFactory = scopeFactory;

            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = kafkaSettings.BootcampServer,
                GroupId = kafkaSettings.GroupId,

                AutoOffsetReset = AutoOffsetReset.Latest,
                EnableAutoCommit = true,
                EnablePartitionEof = true,
                //StatisticsIntervalMs = 5000,
                //SessionTimeoutMs = 6000,

                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslMechanism = SaslMechanism.ScramSha512,

                SaslUsername = kafkaSettings.SaslUsername,
                SaslPassword = kafkaSettings.SaslPassword
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                using (var consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build())
                {
                    string topic = kafkaSettings.KafkaTopic.UserTopic;
                    consumer.Subscribe(topic);

                    await Task.Run(async () =>
                    {
                        while (!stoppingToken.IsCancellationRequested)
                        {
                            var consumeResult = consumer.Consume(stoppingToken);

                            if (consumeResult.IsPartitionEOF)
                            {
                                continue;
                            }

                            var message = consumeResult.Message.Value;

                            using (IServiceScope scope = _scopeFactory.CreateScope())
                            {
                                IServiceKafka _consumerService = scope.ServiceProvider.GetRequiredService<IServiceKafka>();

                                await _consumerService.ConsumeUserAsync(message);
                            }
                        }
                    });

                    consumer.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Kafka Consumer Error : {topic} {message} stack trace {trace}", kafkaSettings.KafkaTopic.UserTopic, ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
