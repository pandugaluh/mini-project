using Project.Service.Course.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Course.Domain.Enities
{
    [Table("Material")]
    public class EntityMaterial : BaseEntity
    {
        [Key]
        public int MaterialId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string MaterialName { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public EntityCourse Course { get; set; }
    }
}
