using AutoMapper;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Application.Mapper
{
    public class MapperUser : Profile
    {
        public MapperUser()
        {
            CreateMap<EntityUser, ResponseUser>().ReverseMap();
        }
    }
}
