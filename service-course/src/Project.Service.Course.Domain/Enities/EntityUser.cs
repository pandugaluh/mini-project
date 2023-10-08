using Project.Service.Course.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service.Course.Domain.Enities
{
    [Table("UserStg")]
    public class EntityUser : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public Guid UserGuid { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        public EntityMember Member { get; set; }
    }
}
