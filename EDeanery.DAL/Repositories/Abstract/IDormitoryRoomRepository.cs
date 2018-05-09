using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IDormitoryRoomRepository : IRepository<DormitoryRoom, int>
    {
        Task AddStudentAsync(int studentId, int dormitoryRoomId);
        Task DeleteStudentAsync(int studentId, int dormitoryRoomId);
    }
}