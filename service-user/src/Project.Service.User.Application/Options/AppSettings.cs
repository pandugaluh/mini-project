namespace Project.Service.User.Application.Options
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public int SqlTimeOut { get; set; }
        public int RetryAttempt { get; set; }
        public int SleepTime { get; set; }
        public string SecretKey { get; set; }
    }

    public class ConnectionStrings
    {
        public string User { get; set; }
    }
}
