using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Project.Service.User.Application.Common;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Options;
using Project.Service.User.Application.Services.User;
using Project.Service.User.Application.Services.User.Login;
using Project.Service.User.Application.Services.User.Register;
using Project.Service.User.Application.Services.User.Remove;
using Project.Service.User.Application.Services.User.Update;
using Project.Service.User.Infrastructure.Kafka.Producer;

namespace Project.Service.User.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IKafkaProducer _kafkaProducer;
        private KafkaSettings kafkaSettings;

        public UserController(ILoggerFactory loggerFactory, IMediator mediator, IOptions<KafkaSettings> options, IKafkaProducer kafkaProducer)
        {
            _logger = loggerFactory.CreateLogger<UserController>();
            _mediator = mediator;
            _kafkaProducer = kafkaProducer;
            kafkaSettings = options.Value;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<JsonResult> Register(RegisterUserRequest request)
        {
            _logger.LogInformation("call api register");
            var res = new GlobalResponse<UserResponse>();

            try
            {
                res.Data = await _mediator.Send(request);
                await _kafkaProducer.SendMessage(kafkaSettings.KafkaTopic.UserTopic, kafkaSettings.KafkaTopic.UserKey, res.Data.ToJsonStringCamelcase());

                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<JsonResult> Login(LoginUserRequest request)
        {
            _logger.LogInformation("call api login");
            var res = new GlobalResponse<UserResponse>();

            try
            {
                res.Data = await _mediator.Send(request);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpDelete]
        [Route("Remove")]
        public async Task<JsonResult> Remove(RemoveUserRequest request)
        {
            _logger.LogInformation("call api remove");
            var res = new GlobalResponse<UserResponse>();

            try
            {
                res.Data = await _mediator.Send(request);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<JsonResult> Update(UpdateUserRequest request)
        {
            _logger.LogInformation("call api update");
            var res = new GlobalResponse<UserResponse>();

            try
            {
                res.Data = await _mediator.Send(request);
                return await HandelSuccess(res);
            }
            catch (Exception e)
            {
                return await HandelException(res, e);
            }
        }
    }
}
