using Microsoft.Extensions.Options;
using Project.Service.User.Application.Interfaces.Repositories;
using Project.Service.User.Application.Options;
using Project.Service.User.Domain.Entities;
using Project.Service.User.Persistance.Common;

namespace Project.Service.User.Persistance.Repositories.User
{
    public class RepositoryUser : DataAccessWithRetryPolicy, IRepositoryUser
    {
        public RepositoryUser(IOptions<AppSettings> options) : base(options, nameof(options.Value.ConnectionStrings.User))
        {
        }

        public async Task<EntityUser> CreateAsync(EntityUser user)
        {
            var dt = await QueryAsync<EntityUser>(
                SQL.INSERT,
                user);

            return dt.FirstOrDefault();
        }

        public async Task<EntityUser> DeleteUserAsync(Guid userGuid)
        {
            var dt = await QueryAsync<EntityUser>(
                SQL.DELETE,
                new { USerGuid = userGuid });

            return dt.FirstOrDefault();
        }

        public async Task<EntityUser> GetByEmailAndPasswordAsync(string email, string password)
        {
            var dt = await QueryAsync<EntityUser>(
                SQL.GET_BY_EMAIL_PASSWORD,
                new { Email = email, Password = password });

            return dt.FirstOrDefault();
        }

        public async Task<EntityUser> GetByEmailAsync(string email)
        {
            var dt = await QueryAsync<EntityUser>(
                SQL.GET_BY_EMAIL,
                new { Email = email });

            return dt.FirstOrDefault();
        }

        public async Task<EntityUser> GetByUserGuidAsync(Guid userGuid)
        {
            var dt = await QueryAsync<EntityUser>(
                SQL.GET_BY_USER_GUID,
                new { USerGuid = userGuid });

            return dt.FirstOrDefault();
        }

        public async Task<EntityUser> UpdateAsync(EntityUser user)
        {
            var dt = await QueryAsync<EntityUser>(
                SQL.UPDATE,
                user);

            return dt.FirstOrDefault();
        }
    }
}
