using AutoMapper;
using MediatR;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Interfaces.Repositories;
using Project.Service.User.Domain.Entities;

namespace Project.Service.User.Application.Services.User.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryUser _repositoryUser;

        public RegisterUserHandler(IMapper mapper, IRepositoryUser repositoryUser)
        {
            _mapper = mapper;
            _repositoryUser = repositoryUser;
        }

        public async Task<UserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var req = _mapper.Map<EntityUser>(request);
            req.UserGuid = Guid.NewGuid();
            req.Password = ExtentionHelper.HashPassword(request.Password);

            var res = await _repositoryUser.CreateAsync(req);

            return _mapper.Map<UserResponse>(res);
        }
    }
}
