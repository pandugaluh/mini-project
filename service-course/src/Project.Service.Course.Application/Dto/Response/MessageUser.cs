namespace Project.Service.Course.Application.Dto.Response
{
    public class MessageUser : BaseDto
    {
        public Guid UserGuid { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
