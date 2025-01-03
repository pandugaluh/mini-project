﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Service.Course.Persistance.Data;

#nullable disable

namespace Project.Service.Course.Persistance.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityCourseMember", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CourseId", "MemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("CourseMember");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityMaterial", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaterialId");

                    b.HasIndex("CourseId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityMember", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MemberId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.ToTable("UserStg");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityCourseMember", b =>
                {
                    b.HasOne("Project.Service.Course.Domain.Enities.EntityCourse", "Course")
                        .WithMany("CourseMembers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.Service.Course.Domain.Enities.EntityMember", "Member")
                        .WithMany("CourseMembers")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityMaterial", b =>
                {
                    b.HasOne("Project.Service.Course.Domain.Enities.EntityCourse", "Course")
                        .WithMany("Materials")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityMember", b =>
                {
                    b.HasOne("Project.Service.Course.Domain.Enities.EntityUser", "User")
                        .WithOne("Member")
                        .HasForeignKey("Project.Service.Course.Domain.Enities.EntityMember", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityCourse", b =>
                {
                    b.Navigation("CourseMembers");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityMember", b =>
                {
                    b.Navigation("CourseMembers");
                });

            modelBuilder.Entity("Project.Service.Course.Domain.Enities.EntityUser", b =>
                {
                    b.Navigation("Member")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
