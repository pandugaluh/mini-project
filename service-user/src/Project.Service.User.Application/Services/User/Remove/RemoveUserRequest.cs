using MediatR;

namespace Project.Service.User.Application.Services.User.Remove
{
    public record RemoveUserRequest(
        Guid UserGuid
        ) : IRequest<UserResponse>;
}
