using Project.Service.User.Application.Dto;

namespace Project.Service.User.Application.Services.User
{
    public class UserResponse : BaseDto
    {
        public Guid UserGuid { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
