using Microsoft.EntityFrameworkCore;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Persistance.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        public DbSet<EntityUser> Users { get; set; }
        public DbSet<EntityMember> Member { get; set; }
        public DbSet<EntityCourse> Course { get; set; }
        public DbSet<EntityCourseMember> CourseMember { get; set; }
        public DbSet<EntityMaterial> Material { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // EntityUser and EntityMember (1-1 relationship):
            modelBuilder.Entity<EntityUser>()
                .HasOne(u => u.Member)
                .WithOne(m => m.User)
                .HasForeignKey<EntityMember>(m => m.UserId);

            // EntityMember and EntityCourseMember (1-N relationship):
            modelBuilder.Entity<EntityMember>()
                .HasMany(m => m.CourseMembers)
                .WithOne(cm => cm.Member)
                .HasForeignKey(cm => cm.MemberId);

            // EntityCourse and EntityCourseMember (N-N relationship):
            modelBuilder.Entity<EntityCourseMember>()
                .HasKey(cm => new { cm.CourseId, cm.MemberId });

            modelBuilder.Entity<EntityCourseMember>()
                .HasOne(cm => cm.Course)
                .WithMany(c => c.CourseMembers)
                .HasForeignKey(cm => cm.CourseId);

            modelBuilder.Entity<EntityCourseMember>()
                .HasOne(cm => cm.Member)
                .WithMany(m => m.CourseMembers)
                .HasForeignKey(cm => cm.MemberId);

            // EntityCourse and EntityMaterial (1-N relationship):
            modelBuilder.Entity<EntityCourse>()
                .HasMany(c => c.Materials)
                .WithOne(m => m.Course)
                .HasForeignKey(m => m.CourseId);


        }
    }
}
