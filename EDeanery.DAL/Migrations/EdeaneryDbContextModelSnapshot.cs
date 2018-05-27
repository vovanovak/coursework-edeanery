﻿// <auto-generated />
using EDeanery.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EDeanery.DAL.Migrations
{
    [DbContext(typeof(EdeaneryDbContext))]
    partial class EdeaneryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryEntity", b =>
                {
                    b.Property<int>("DormitoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaxCountOfMembers");

                    b.Property<string>("Name");

                    b.HasKey("DormitoryId");

                    b.ToTable("Dormitories");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryFacultyEntity", b =>
                {
                    b.Property<int>("DormitoryFacultyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DormitoryId");

                    b.Property<int>("FacultyId");

                    b.HasKey("DormitoryFacultyId");

                    b.HasIndex("DormitoryId");

                    b.HasIndex("FacultyId");

                    b.ToTable("DormitoryFaculties");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryRoomEntity", b =>
                {
                    b.Property<int>("DormitoryRoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DormitoryId");

                    b.Property<string>("DormityRoomName");

                    b.Property<int>("MaxCountInRoom");

                    b.HasKey("DormitoryRoomId");

                    b.HasIndex("DormitoryId");

                    b.ToTable("DormitoryRooms");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryRoomStudentEntity", b =>
                {
                    b.Property<int>("DormitoryRoomStudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DormitoryRoomId");

                    b.Property<int>("StudentId");

                    b.HasKey("DormitoryRoomStudentId");

                    b.HasIndex("DormitoryRoomId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("DormitoryRoomStudents");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.FacultyEntity", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.GroupEntity", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.Property<int>("SpecialityId");

                    b.HasKey("GroupId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.GroupStudentEntity", b =>
                {
                    b.Property<int>("GroupStudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("StudentId");

                    b.HasKey("GroupStudentId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupStudents");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.SpecialityEntity", b =>
                {
                    b.Property<int>("SpecialityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacultyId");

                    b.Property<string>("SpecialityName");

                    b.HasKey("SpecialityId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.StudentEntity", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("Course");

                    b.Property<int>("DormitoryRoomStudentId");

                    b.Property<string>("FacultyName");

                    b.Property<string>("FathersName");

                    b.Property<string>("FirstName");

                    b.Property<int>("GroupStudentId");

                    b.Property<string>("IdentificationCode");

                    b.Property<string>("LastName");

                    b.Property<bool>("OnBudget");

                    b.Property<string>("PassportIdentifier");

                    b.Property<string>("SpecialityName");

                    b.Property<DateTime>("StartOfLearning");

                    b.Property<string>("StudentTicketId");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupStudentId")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryFacultyEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.DormitoryEntity", "DormitoryEntity")
                        .WithMany("DormitoryFaculties")
                        .HasForeignKey("DormitoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EDeanery.DAL.DAOs.FacultyEntity", "FacultyEntity")
                        .WithMany("DormitoryFaculties")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryRoomEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.DormitoryEntity", "DormitoryEntity")
                        .WithMany("DormitoryRooms")
                        .HasForeignKey("DormitoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.DormitoryRoomStudentEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.DormitoryRoomEntity", "DormitoryRoomEntity")
                        .WithMany("DormitoryRoomStudents")
                        .HasForeignKey("DormitoryRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EDeanery.DAL.DAOs.StudentEntity", "StudentEntity")
                        .WithOne("DormitoryRoomStudentEntity")
                        .HasForeignKey("EDeanery.DAL.DAOs.DormitoryRoomStudentEntity", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.GroupEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.SpecialityEntity", "SpecialityEntity")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.GroupStudentEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.GroupEntity", "GroupEntity")
                        .WithMany("GroupStudents")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.SpecialityEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.FacultyEntity", "FacultyEntity")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EDeanery.DAL.DAOs.StudentEntity", b =>
                {
                    b.HasOne("EDeanery.DAL.DAOs.GroupStudentEntity", "GroupStudentEntity")
                        .WithOne("StudentEntity")
                        .HasForeignKey("EDeanery.DAL.DAOs.StudentEntity", "GroupStudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
