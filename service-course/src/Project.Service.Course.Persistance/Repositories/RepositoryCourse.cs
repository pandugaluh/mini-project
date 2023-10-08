using Microsoft.EntityFrameworkCore;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Domain.Enities;
using Project.Service.Course.Persistance.Data;

namespace Project.Service.Course.Persistance.Repositories
{
    public class RepositoryCourse : IRepositoryCourse
    {
        private readonly DataContext _dataContext;

        public RepositoryCourse(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<EntityCourse> CreateAsync(EntityCourse course)
        {
            _dataContext.Course.Add(course);
            await _dataContext.SaveChangesAsync();

            return course;
        }

        public async Task DeleteAsync(EntityCourse course)
        {
            _dataContext.Remove(course);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<EntityCourse>> GetAllAsync()
        {
            return await _dataContext.Course.AsNoTracking().ToListAsync();
        }

        public async Task<EntityCourse> GetByIdAsync(int courseId)
        {
            return await _dataContext.Course.Where(c => c.CourseId == courseId).FirstOrDefaultAsync();
        }

        public async Task<EntityCourse> GetByNsmeAsync(string courseNsme)
        {
            return await _dataContext.Course.Where(c => c.CourseName == courseNsme).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(EntityCourse course)
        {
            _dataContext.Update(course);
            await _dataContext.SaveChangesAsync();
        }
    }
}
