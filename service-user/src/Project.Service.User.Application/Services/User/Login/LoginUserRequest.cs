using MediatR;

namespace Project.Service.User.Application.Services.User.Login
{
    public record LoginUserRequest(
        string Email,
        string Password
        ) : IRequest<UserResponse>;
}
