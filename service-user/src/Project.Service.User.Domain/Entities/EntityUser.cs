using Project.Service.User.Domain.Common;

namespace Project.Service.User.Domain.Entities
{
    public class EntityUser : BaseEntity
    {
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
