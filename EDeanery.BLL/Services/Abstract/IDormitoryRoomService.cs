using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IDormitoryRoomService : IService<DormitoryRoom, int>
    {
        Task SetDormitoryRoomsAsync(int dormitoryId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId);
    }
}