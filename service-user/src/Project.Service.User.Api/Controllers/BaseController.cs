using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Service.User.Application.Common;
using System.Net;

namespace Project.Service.User.Api.Controllers
{
    public class BaseController : Controller
    {
        protected ILogger _logger { get; set; }

        public async Task<JsonResult> HandelSuccess<T> (T res)
        {
            return new JsonResult(res);
        }

        public async Task<JsonResult> HandelException<T>(GlobalResponse<T> res, Exception ex)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;

            if (ex.GetType() == typeof(ValidationException))
            {
                _logger.LogError(ex.Message);
                res.ErrorMessage = new List<string> { ex.Message };
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (ex.GetType() == typeof(FluentValidation.ValidationException))
            {
                _logger.LogError(ex.Message);
                res.ErrorMessage = JsonConvert.DeserializeObject<List<string>>(ex.Message);
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (ex.GetType() == typeof(HttpRequestException))
            {
                _logger.LogError(ex.Message);
                var e = ex as HttpRequestException;
                res.ErrorMessage = new List<string> { ex.Message };
                httpStatusCode = e.StatusCode ?? HttpStatusCode.BadRequest;
            }
            else
            {
                _logger.LogError($"{ex.Message} : {ex.StackTrace}");
                res.ErrorMessage = new List<string> { "one or more errors occured" };
            }

            return new JsonResult(res);
        }
    }
}