using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IDormitoryRoomRepository : IRepository<DormitoryRoom, int>
    {
        Task SetDormitoryRoomsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId);
        Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory();
        Task<DormitoryRoom> GetDormitoryRoomByStudentId(int studentId);
    }
}