using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Application.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        Task CreateAsync(EntityUser user);
        Task<List<EntityUser>> GetAllAsync();
    }
}
