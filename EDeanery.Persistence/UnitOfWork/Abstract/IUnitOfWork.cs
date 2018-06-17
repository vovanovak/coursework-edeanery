using System.Threading.Tasks;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace EDeanery.Persistence.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IDormitoryRepository DormitoryRepository { get; }
        IDormitoryRoomRepository DormitoryRoomRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        IGroupRepository GroupRepository { get; }
        ISpecialityRepository SpecialityRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task<IDbContextTransaction> BeginTransaction();
        Task<int> SaveChangesAsync();
    }
}