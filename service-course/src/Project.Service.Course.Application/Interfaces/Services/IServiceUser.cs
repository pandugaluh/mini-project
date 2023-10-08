using Project.Service.Course.Application.Dto;
using Project.Service.Course.Application.Dto.Response;

namespace Project.Service.Course.Application.Interfaces.Services
{
    public interface IServiceUser
    {
        Task<List<ResponseUser>> GetAllAsync();
        Task<ResponseUserPaged> GetPagedAsync(RequestPaged requestPaged);
    }
}
