using System.ComponentModel.DataAnnotations;

namespace Project.Service.Course.Application.Dto.Requests
{
    public class RequestCourseUpdate
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "CourseName is required.")]
        [MinLength(3, ErrorMessage = "name must be between 3 and 150 character")]
        [MaxLength(150, ErrorMessage = "name must be between 3 and 150 character")]
        [RegularExpression(@"^[a-zA-Z0-9 ^<>.,?;:'()!~%\-_@#/*""\s]+$", ErrorMessage = "Invalid Character")]
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
