namespace Project.Service.Course.Application.Dto.Response
{
    public class ResponseCourse : BaseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
