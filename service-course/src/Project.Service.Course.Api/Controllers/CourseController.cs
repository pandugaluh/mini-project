using Microsoft.AspNetCore.Mvc;
using Project.Service.Course.Application.Common;
using Project.Service.Course.Application.Dto.Requests;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Application.Interfaces.Services;

namespace Project.Service.Course.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : BaseController
    {
        private IServiceCourse _serviceCourse;

        public CourseController(ILoggerFactory loggerFactory, IServiceCourse serviceCourse)
        {
            _logger = loggerFactory.CreateLogger<CourseController>();
            _serviceCourse = serviceCourse;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<JsonResult> Add(RequestCourseCreate request)
        {
            _logger.LogInformation("call api add");
            var res = new GlobalResponse<ResponseCourse>();

            try
            {
                res.Data = await _serviceCourse.CreateAsync(request);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<JsonResult> Edit(RequestCourseUpdate request)
        {
            _logger.LogInformation("call api edit");
            var res = new GlobalResponse<ResponseCourse>();

            try
            {
                res.Data = await _serviceCourse.UpdateAsync(request);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<JsonResult> Remove(int courseId)
        {
            _logger.LogInformation("call api remove");
            var res = new GlobalResponse<ResponseCourse>();

            try
            {
                res.Data = await _serviceCourse.DeleteAsync(courseId);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<JsonResult> GetById(int courseId)
        {
            _logger.LogInformation("call api get course");
            var res = new GlobalResponse<ResponseCourse>();

            try
            {
                res.Data = await _serviceCourse.GetByIdAsync(courseId);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<JsonResult> GetAll()
        {
            _logger.LogInformation("call api get all");
            var res = new GlobalResponse<List<ResponseCourse>>();

            try
            {
                res.Data = await _serviceCourse.GetAllAsync();
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }
    }
}