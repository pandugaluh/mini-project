using AutoMapper;
using Project.Service.Course.Application.Dto.Requests;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Application.Mapper
{
    public class MapperCourse : Profile
    {
        public MapperCourse() 
        {
            CreateMap<EntityCourse, ResponseCourse>().ReverseMap();
            CreateMap<RequestCourseCreate, EntityCourse>().ReverseMap();
            CreateMap<RequestCourseUpdate, EntityCourse>().ReverseMap();
        }
    }
}
