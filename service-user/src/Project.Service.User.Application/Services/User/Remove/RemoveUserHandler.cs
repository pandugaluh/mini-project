using AutoMapper;
using MediatR;
using Project.Service.User.Application.Interfaces.Repositories;

namespace Project.Service.User.Application.Services.User.Remove
{
    public class RemoveUserHandler : IRequestHandler<RemoveUserRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryUser _repositoryUser;

        public RemoveUserHandler(IMapper mapper, IRepositoryUser repositoryUser)
        {
            _mapper = mapper;
            _repositoryUser = repositoryUser;
        }

        public async Task<UserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
        {
            var res = await _repositoryUser.DeleteUserAsync(request.UserGuid);

            return _mapper.Map<UserResponse>(res);
        }
    }
}
