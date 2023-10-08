using AutoMapper;
using MediatR;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Interfaces.Repositories;

namespace Project.Service.User.Application.Services.User.Login
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, UserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryUser _repositoryUser;

        public LoginUserHandler(IMapper mapper, IRepositoryUser repositoryUser)
        {
            _mapper = mapper;
            _repositoryUser = repositoryUser;
        }

        public async Task<UserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var res = await _repositoryUser.GetByEmailAndPasswordAsync(request.Email, ExtentionHelper.HashPassword(request.Password));

            // do something

            return _mapper.Map<UserResponse>(res);
        }
    }
}
