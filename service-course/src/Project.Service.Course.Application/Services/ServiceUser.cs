using AutoMapper;
using Project.Service.Course.Application.Dto;
using Project.Service.Course.Application.Dto.Response;
using Project.Service.Course.Application.Interfaces.Repositories;
using Project.Service.Course.Application.Interfaces.Services;

namespace Project.Service.Course.Application.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;
        private readonly IMapper _mapper;

        public ServiceUser(IRepositoryUser repositoryUser, IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _mapper = mapper;
        }

        public async Task<List<ResponseUser>> GetAllAsync()
        {
            var res = await _repositoryUser.GetAllAsync();
            return _mapper.Map<List<ResponseUser>>(res);
        }

        public async Task<ResponseUserPaged> GetPagedAsync(RequestPaged requestPaged)
        {
            int pageNo = requestPaged.PageNo < 1 ? 1 : requestPaged.PageNo;
            int pageSize = requestPaged.PageSize < 1 ? 10 : requestPaged.PageSize;

            var res = await _repositoryUser.GetAllAsync();
            var resMapped = _mapper.Map<List<ResponseUser>>(res);

            return new ResponseUserPaged()
            {
                PageNo = pageNo,
                PageSize = pageSize,
                TotalCount = resMapped.Count,
                Users = resMapped.Skip(pageNo - 1).Take(pageSize).ToList()
            };
        }
    }
}
