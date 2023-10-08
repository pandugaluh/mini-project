using Project.Service.Course.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Course.Domain.Enities
{
    [Table("Member")]
    public class EntityMember : BaseEntity
    {
        [Key]
        public int MemberId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string MemberType { get; set; }

        public DateTime JoinDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public EntityUser User { get; set; }

        public List<EntityCourseMember> CourseMembers { get; set; }
    }
}
