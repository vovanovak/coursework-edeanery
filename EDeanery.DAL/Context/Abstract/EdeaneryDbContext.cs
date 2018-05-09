using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Context.Abstract
{
    public class EdeaneryDbContext : DbContext, IEdeaneryDbContext
    {
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<DormitoryFaculty> DormitoryFaculties { get; set; }
        public DbSet<DormitoryRoom> DormitoryRooms { get; set; }
        public DbSet<DormitoryRoomStudent> DormitoryRoomStudents { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupStudent> GroupStudents { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}