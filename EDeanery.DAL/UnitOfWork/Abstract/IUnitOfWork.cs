using System.Threading.Tasks;
using EDeanery.DAL.Repositories.Abstract;

namespace EDeanery.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IDormitoryRepository DormitoryRepository { get; set; }
        IDormitoryRoomRepository DormitoryRoomRepository { get; set; }
        IFacultyRepository FacultyRepository { get; set; }
        IGroupRepository GroupRepository { get; set; }
        ISpecialityRepository SpecialityRepository { get; set; }
        IStudentRepository StudentRepository { get; set; }
        Task<int> SaveChangesAsync();
    }
}