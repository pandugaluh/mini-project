using MediatR;

namespace Project.Service.User.Application.Services.User.Update
{
    public record UpdateUserRequest(
        Guid UserGuid,
        string Email,
        string Password,
        string FirstName,
        string LastName
        ) : IRequest<UserResponse>;
}
