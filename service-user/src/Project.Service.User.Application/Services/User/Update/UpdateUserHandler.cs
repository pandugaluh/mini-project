using AutoMapper;
using MediatR;
using Project.Service.User.Application.Interfaces.Repositories;
using Project.Service.User.Domain.Entities;

namespace Project.Service.User.Application.Services.User.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryUser _repositoryUser;

        public UpdateUserHandler(IMapper mapper, IRepositoryUser repositoryUser)
        {
            _mapper = mapper;
            _repositoryUser = repositoryUser;
        }

        public async Task<UserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var req = _mapper.Map<EntityUser>(request);
            var res = await _repositoryUser.UpdateAsync(req);

            return _mapper.Map<UserResponse>(res);
        }
    }
}
