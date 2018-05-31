using System.Threading.Tasks;
using EDeanery.DAL.DAOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EDeanery.DAL.Context.Abstract
{
    public interface IEdeaneryDbContext
    {
        DbSet<DormitoryEntity> Dormitories { get; set; }
        DbSet<DormitoryFacultyEntity> DormitoryFaculties { get; set; }
        DbSet<DormitoryRoomEntity> DormitoryRooms { get; set; }
        DbSet<DormitoryRoomStudentEntity> DormitoryRoomStudents { get; set; }
        DbSet<FacultyEntity> Faculties { get; set; }
        DbSet<GroupEntity> Groups { get; set; }
        DbSet<GroupStudentEntity> GroupStudents { get; set; }
        DbSet<SpecialityEntity> Specialities { get; set; }
        DbSet<StudentEntity> Students { get; set; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}