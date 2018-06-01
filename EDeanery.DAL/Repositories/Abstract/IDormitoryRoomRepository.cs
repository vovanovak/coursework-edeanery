using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IDormitoryRoomRepository : IRepository<DormitoryRoom, int>
    {
        Task SetStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds);
        Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId);
    }
}