namespace Project.Service.User.Domain.Common
{
    public class BaseEntity
    {
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
    }
}
