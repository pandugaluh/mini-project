using Microsoft.EntityFrameworkCore;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Domain.Enities;
using Project.Service.Course.Persistance.Data;

namespace Project.Service.Course.Persistance.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly DataContext _dataContext;

        public RepositoryUser(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateAsync(EntityUser user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<EntityUser>> GetAllAsync()
        {
            return await _dataContext.Users.AsNoTracking().ToListAsync();
        }
    }
}
