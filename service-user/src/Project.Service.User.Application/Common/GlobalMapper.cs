using AutoMapper;
using Project.Service.User.Application.Dto;
using Project.Service.User.Domain.Common;

namespace Project.Service.User.Application.Common
{
    public class GlobalMapper : Profile
    {
        public GlobalMapper()
        {
            CreateMap<BaseDto, BaseEntity>().ReverseMap();
        }
    }
}
