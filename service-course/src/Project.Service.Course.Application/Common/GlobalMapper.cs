using AutoMapper;
using Project.Service.Course.Application.Dto;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Domain.Common;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Application.Common
{
    public class GlobalMapper : Profile
    {
        public GlobalMapper()
        {
            CreateMap<BaseDto, BaseEntity>().ReverseMap();
            CreateMap<MessageUser, EntityUser>().ReverseMap();
        }
    }
}
