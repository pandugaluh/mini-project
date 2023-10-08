using Project.Service.Course.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Course.Domain.Enities
{
    [Table("Course")]
    public class EntityCourse : BaseEntity
    {
        [Key]
        public int CourseId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string CourseName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<EntityCourseMember> CourseMembers { get; set; }

        public List<EntityMaterial> Materials { get; set; }
    }
}
