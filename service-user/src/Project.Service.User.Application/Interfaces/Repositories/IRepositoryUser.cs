using Project.Service.User.Domain.Entities;

namespace Project.Service.User.Application.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        Task<EntityUser> CreateAsync(EntityUser user);
        Task<EntityUser> GetByEmailAsync(string email);
        Task<EntityUser> GetByEmailAndPasswordAsync(string email, string password);
        Task<EntityUser> GetByUserGuidAsync(Guid userGuid);
        Task<EntityUser> DeleteUserAsync(Guid userGuid);
        Task<EntityUser> UpdateAsync(EntityUser user);
    }
}
