using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Application.Mapper;
using Project.Service.Course.Application.Services;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Test.Service
{
    public class CourseServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IRepositoryCourse> _mockRepo;

        private readonly ServiceCourse _sut;

        private readonly Fixture _fixture;

        public CourseServiceTest()
        {
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapperCourse())).CreateMapper();
            _mockRepo = new Mock<IRepositoryCourse>();

            _sut = new ServiceCourse(_mockRepo.Object, _mapper);

            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void GetAllAsync_ListIsEmpty_ReturnEmptyList()
        {
            // arrange
            _mockRepo.Setup(c => c.GetAllAsync()).Returns(Task.FromResult(new List<EntityCourse>()));

            // act
            List<ResponseCourse> returnTask = _sut.GetAllAsync().Result;

            // assert
            returnTask.Should().BeEmpty();
        }

        [Fact]
        public void GetAllAsync_ListIsNotEmpty_ReturnList()
        {
            // Arrange
            List<EntityCourse> _listSyllabus = _fixture.CreateMany<EntityCourse>().ToList();

            _mockRepo.Setup(c => c.GetAllAsync()).Returns(Task.FromResult(_listSyllabus));

            // Act
            List<ResponseCourse> returnTask = _sut.GetAllAsync().Result;

            // Assert
            returnTask.Should().NotBeEmpty();
            returnTask.Should().HaveCount(_listSyllabus.Count());
        }
    }
}
