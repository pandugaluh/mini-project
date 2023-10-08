using Project.Service.Course.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Course.Domain.Enities
{
    [Table("CourseMember")]
    public class EntityCourseMember : BaseEntity
    {
        public bool IsActive { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public EntityMember Member { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public EntityCourse Course { get; set; }
    }
}
