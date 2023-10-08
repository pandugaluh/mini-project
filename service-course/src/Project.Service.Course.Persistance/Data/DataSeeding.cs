using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Service.Course.Domain.Enities;

namespace Project.Service.Course.Persistance.Data
{
    public static class DataSeeding
    {
        public static void SeedData(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();
                dataContext?.Database.Migrate();

                if (!dataContext.Users.Any()
                    && !dataContext.Member.Any()
                    && !dataContext.Course.Any()
                    && !dataContext.CourseMember.Any()
                    && !dataContext.Material.Any())
                {
                    var user1 = new EntityUser()
                    {
                        UserGuid = Guid.NewGuid(),
                        Email = "email1@mail.com",
                        FirstName = "Ahmad",
                        LastName = "Budi",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    var user2 = new EntityUser()
                    {
                        UserGuid = Guid.NewGuid(),
                        Email = "email2@mail.com",
                        FirstName = "Candra",
                        LastName = "Dodi",
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    dataContext.Users.AddRange(user1, user2);

                    var member1 = new EntityMember()
                    {
                        MemberType = "Type1",
                        JoinDate = DateTime.Now,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        User = user1
                    };

                    var member2 = new EntityMember()
                    {
                        MemberType = "Type2",
                        JoinDate = DateTime.Now,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        User = user2
                    };

                    dataContext.Member.AddRange(member1, member2);

                    var course1 = new EntityCourse()
                    {
                        CourseName = "Course 1",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(3),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    var course2 = new EntityCourse()
                    {
                        CourseName = "Course 2",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(2),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    dataContext.Course.AddRange(course1, course2);

                    dataContext.CourseMember.AddRange(
                        new EntityCourseMember() { Member = member1, Course = course1, IsActive = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                        new EntityCourseMember() { Member = member2, Course = course2, IsActive = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now }
                    );

                    dataContext.Material.AddRange(
                        new EntityMaterial() { MaterialName = "Material 1", Course = course1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                        new EntityMaterial() { MaterialName = "Material 2", Course = course1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now },
                        new EntityMaterial() { MaterialName = "Material 3", Course = course2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now }
                    );

                    dataContext.SaveChanges();
                }
            }
        }
    }
}
