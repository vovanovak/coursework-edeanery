using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Context.Abstract
{
    public interface IEdeaneryDbContext
    {
        DbSet<Dormitory> Dormitories { get; set; }
        DbSet<DormitoryFaculty> DormitoryFaculties { get; set; }
        DbSet<DormitoryRoom> DormitoryRooms { get; set; }
        DbSet<DormitoryRoomStudent> DormitoryRoomStudents { get; set; }
        DbSet<Faculty> Faculties { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<GroupStudent> GroupStudents { get; set; }
        DbSet<Speciality> Specialities { get; set; }
        DbSet<Student> Students { get; set; }
    }
}