using AutoMapper;
using Newtonsoft.Json;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Application.Interfaces.Services;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Application.Services
{
    public class ServiceKafka : IServiceKafka
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IMapper _mapper;

        public ServiceKafka(IRepositoryUser repositoryUser, IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        public async Task ConsumeUserAsync(string message)
        {
            var messageUser = JsonConvert.DeserializeObject<MessageUser>(message);

            var user = _mapper.Map<EntityUser>(messageUser);
            await _repositoryUser.CreateAsync(user);
        }
    }
}
