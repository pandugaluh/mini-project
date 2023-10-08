using Project.Service.Course.Application.Dto.Requests;
using Project.Service.Course.Application.Dto.Response;

namespace Project.Service.Course.Application.Interfaces.Services
{
    public interface IServiceCourse
    {
        Task<ResponseCourse> CreateAsync(RequestCourseCreate request);
        Task<ResponseCourse> UpdateAsync(RequestCourseUpdate request);
        Task<ResponseCourse> DeleteAsync(int courseId);
        Task<ResponseCourse> GetByIdAsync(int courseId);
        Task<List<ResponseCourse>> GetAllAsync();
    }
}
