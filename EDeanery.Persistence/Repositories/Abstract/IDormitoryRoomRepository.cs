using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;

namespace EDeanery.Persistence.Repositories.Abstract
{
    public interface IDormitoryRoomRepository : IRepository<DormitoryRoom, int>
    {
        void SetDormitoryRooms(int dormitoryRoomId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId);
        Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory();
        Task<DormitoryRoom> GetDormitoryRoomByStudentId(int studentId);
        bool IsDormitoryRoomNameUnique(string name);
    }
}