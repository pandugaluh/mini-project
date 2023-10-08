using Microsoft.AspNetCore.Mvc;
using Project.Service.Course.Application.Common;
using Project.Service.Course.Application.Dto;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Application.Interfaces.Services;

namespace Project.Service.Course.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private IServiceUser _serviceUser;

        public UserController(ILoggerFactory loggerFactory, IServiceUser serviceUser)
        {
            _logger = loggerFactory.CreateLogger<CourseController>();
            _serviceUser = serviceUser;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<JsonResult> GetAll()
        {
            _logger.LogInformation("call api get all");
            var res = new GlobalResponse<List<ResponseUser>>();

            try
            {
                res.Data = await _serviceUser.GetAllAsync();
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpPost]
        [Route("GetPaged")]
        public async Task<JsonResult> GetPaged(RequestPaged request)
        {
            _logger.LogInformation("call api get paged");
            var res = new GlobalResponse<ResponseUserPaged>();

            try
            {
                res.Data = await _serviceUser.GetPagedAsync(request);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }
    }
}
