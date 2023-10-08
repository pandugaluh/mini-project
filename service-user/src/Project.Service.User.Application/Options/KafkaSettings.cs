namespace Project.Service.User.Application.Options
{
    public class KafkaSettings
    {
        public string BootcampServer { get; set; }
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
        public KafkaTopic KafkaTopic { get; set; }
    }

    public class KafkaTopic
    {
        public string UserTopic { get; set; }
        public string UserKey { get; set; }
    }
}
