using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Application.Interfaces.Repositories
{
    public interface IRepositoryCourse
    {
        Task<EntityCourse> CreateAsync(EntityCourse course);
        Task<EntityCourse> GetByIdAsync(int courseId);
        Task<EntityCourse> GetByNsmeAsync(string courseNsme);
        Task<List<EntityCourse>> GetAllAsync();
        Task DeleteAsync(EntityCourse course);
        Task UpdateAsync(EntityCourse course);

    }
}
