using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IDormitoryRoomService : IService<DormitoryRoom, int>
    {
        Task AddStudentAsync(int studentId, int dormitoryRoomId);
        Task DeleteStudentAsync(int studentId, int dormitoryRoomId);
    }
}