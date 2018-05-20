﻿using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.Context.Configurations;
using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Context
{
    public class EdeaneryDbContext : DbContext, IEdeaneryDbContext
    {
        public DbSet<DormitoryEntity> Dormitories { get; set; }
        public DbSet<DormitoryFacultyEntity> DormitoryFaculties { get; set; }
        public DbSet<DormitoryRoomEntity> DormitoryRooms { get; set; }
        public DbSet<DormitoryRoomStudentEntity> DormitoryRoomStudents { get; set; }
        public DbSet<FacultyEntity> Faculties { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<GroupStudentEntity> GroupStudents { get; set; }
        public DbSet<SpecialityEntity> Specialities { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DormitoryFacultyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DormitoryRoomStudentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DormitoryRoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DormitoryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupStudentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentTypeConfiguration());
        }
    }
}