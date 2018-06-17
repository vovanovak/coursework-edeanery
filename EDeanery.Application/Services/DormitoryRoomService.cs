using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal class DormitoryRoomService : Service<DormitoryRoom, int>, IDormitoryRoomService
    {
        private readonly IDormitoryRoomRepository _dormitoryRoomRepository;
        
        public DormitoryRoomService(IDormitoryRoomRepository dormitoryRoomRepository) : base(dormitoryRoomRepository)
        {
            _dormitoryRoomRepository = dormitoryRoomRepository;
        }

        public async Task SetDormitoryRoomsAsync(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            _dormitoryRoomRepository.SetDormitoryRooms(dormitoryId, dormitoryRoomIds);
        }

        public async Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds)
        {
            await _dormitoryRoomRepository.SetDormitoryRoomStudentsAsync(dormitoryRoomId, studentIds);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            return await _dormitoryRoomRepository.GetRoomsWithFreeSpaces(dormitoryId);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId)
        {
            return await _dormitoryRoomRepository.GetRoomsByDormitoryId(dormitoryId);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory()
        {
            return await _dormitoryRoomRepository.GetRoomsWithoutDormitory();
        }

        public bool IsDormitoryRoomNameUnique(string name)
        {
            return _dormitoryRoomRepository.IsDormitoryRoomNameUnique(name);
        }
    }
}