using System.Threading.Tasks;
using EDeanery.DAL.Repositories.Abstract;

namespace EDeanery.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IDormitoryRepository DormitoryRepository { get; }
        IDormitoryRoomRepository DormitoryRoomRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        IGroupRepository GroupRepository { get; }
        ISpecialityRepository SpecialityRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task<int> SaveChangesAsync();
    }
}