namespace Project.Service.Course.Application.Dto.Response
{
    public class ResponseUserPaged
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<ResponseUser> Users { get; set; }

    }
}
