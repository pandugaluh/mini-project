using MediatR;

namespace Project.Service.User.Application.Services.User.Register
{
    public record RegisterUserRequest(
        string Email,
        string Password,
        string FirstName,
        string LastName
        ) : IRequest<UserResponse>;
}
