using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Interfaces.Repositories;
using Project.Service.User.Application.Services.User;
using Project.Service.User.Application.Services.User.Register;
using Project.Service.User.Domain.Entities;

namespace Project.Service.User.Test.Service.User
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryUser> _mockRepo;
        private readonly Mock<IConfiguration> _mockICongif;

        private readonly CancellationToken _cancellationToken;

        private readonly Fixture _fixture;

        public UserServiceTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new UserMapper())).CreateMapper();
            _mockRepo = new Mock<IRepositoryUser>();
            _mockICongif = new Mock<IConfiguration>();

            _cancellationToken = new CancellationToken();

            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task RegisterUserHandler_RegisteredUser()
        {
            // arrange
            var handler = new RegisterUserHandler(_mapper, _mockRepo.Object);

            _mockICongif.Setup(x => x["AppSettings:SecretKey"]).Returns("your-test-secret-key");
            ExtentionHelper.Initialize(_mockICongif.Object);

            var userEntity = _fixture.Create<EntityUser>();
            var req = _mapper.Map<RegisterUserRequest>(userEntity);
            _mockRepo.Setup(x => x.CreateAsync(It.IsAny<EntityUser>())).Returns(Task.FromResult(userEntity));

            // act
            var returnTask = await handler.Handle(req, _cancellationToken);

            // assert
            returnTask.Should().BeOfType<UserResponse>();
        }
    }
}