using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Context.Abstract
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
    }
}