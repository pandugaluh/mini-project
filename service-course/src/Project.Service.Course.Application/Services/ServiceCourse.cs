using AutoMapper;
using Project.Service.Course.Application.Dto.Requests;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Application.Interfaces.Services;
using Project.Service.Course.Domain.Enities;
using System.ComponentModel.DataAnnotations;

namespace Project.Service.Course.Application.Services
{
    public class ServiceCourse : IServiceCourse
    {
        private readonly IRepositoryCourse _repositoryCourse;
        private readonly IMapper _mapper;

        public ServiceCourse(IRepositoryCourse repositoryCourse, IMapper mapper)
        {
            _repositoryCourse = repositoryCourse;
            _mapper = mapper;
        }

        public async Task<ResponseCourse> CreateAsync(RequestCourseCreate request)
        {
            var isNameExist = await _repositoryCourse.GetByNsmeAsync(request.CourseName);
            if (isNameExist is not null)
            {
                throw new ValidationException("Course name already exist!");
            }

            var req = _mapper.Map<EntityCourse>(request);
            req.DateCreated = DateTime.Now;
            req.DateUpdated = DateTime.Now;

            var res = await _repositoryCourse.CreateAsync(req);
            return _mapper.Map<ResponseCourse>(res);
        }

        public async Task<ResponseCourse> DeleteAsync(int courseId)
        {
            var existingCourse = await _repositoryCourse.GetByIdAsync(courseId);
            if (existingCourse is null)
            {
                throw new ValidationException("Course does not exist!");
            }

            await _repositoryCourse.DeleteAsync(existingCourse);
            return _mapper.Map<ResponseCourse>(existingCourse);
        }

        public async Task<List<ResponseCourse>> GetAllAsync()
        {
            var res = await _repositoryCourse.GetAllAsync();
            return _mapper.Map<List<ResponseCourse>>(res);
        }

        public async Task<ResponseCourse> GetByIdAsync(int courseId)
        {
            var res = await _repositoryCourse.GetByIdAsync(courseId);
            if (res is null)
            {
                throw new ValidationException("Course does not exist!");
            }

            return _mapper.Map<ResponseCourse>(res);
        }

        public async Task<ResponseCourse> UpdateAsync(RequestCourseUpdate request)
        {
            var existingCourse = await _repositoryCourse.GetByIdAsync(request.CourseId);
            if (existingCourse is null)
            {
                throw new ValidationException("Course does not exist!");
            }

            var isNameExist = await _repositoryCourse.GetByNsmeAsync(request.CourseName);
            if (isNameExist is not null)
            {
                throw new ValidationException("Course name already exist!");
            }

            existingCourse.CourseName = request.CourseName;
            existingCourse.StartDate = request.StartDate;
            existingCourse.EndDate = request.EndDate;
            existingCourse.DateUpdated = DateTime.Now;

            await _repositoryCourse.UpdateAsync(existingCourse);

            return _mapper.Map<ResponseCourse>(existingCourse);
        }
    }
}
