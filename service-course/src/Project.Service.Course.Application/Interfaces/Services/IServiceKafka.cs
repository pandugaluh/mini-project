namespace Project.Service.Course.Application.Interfaces.Services
{
    public interface IServiceKafka
    {
        Task ConsumeUserAsync(string message);
    }
}
