using AutoMapper;
using Project.Service.User.Application.Services.User.Login;
using Project.Service.User.Application.Services.User.Register;
using Project.Service.User.Application.Services.User.Remove;
using Project.Service.User.Application.Services.User.Update;
using Project.Service.User.Domain.Entities;

namespace Project.Service.User.Application.Services.User
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<EntityUser, UserResponse>().ReverseMap();
            CreateMap<RegisterUserRequest, EntityUser>().ReverseMap();
            CreateMap<LoginUserRequest, EntityUser>().ReverseMap();
            CreateMap<RemoveUserRequest, EntityUser>().ReverseMap();
            CreateMap<UpdateUserRequest, EntityUser>().ReverseMap();
        }
    }
}
