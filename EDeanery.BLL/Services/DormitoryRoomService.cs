using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    internal class DormitoryRoomService : Service<DormitoryRoom, int>, IDormitoryRoomService
    {
        public DormitoryRoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<DormitoryRoom, int> Repository => UnitOfWork.DormitoryRoomRepository;

        public async Task SetDormitoryRoomsAsync(int dormitoryId, IReadOnlyCollection<int> dormitoryRoomIds)
        {
            await UnitOfWork.DormitoryRoomRepository.SetDormitoryRoomsAsync(dormitoryId, dormitoryRoomIds);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task SetDormitoryRoomStudentsAsync(int dormitoryRoomId, IReadOnlyCollection<int> studentIds)
        {
            await UnitOfWork.DormitoryRoomRepository.SetDormitoryRoomStudentsAsync(dormitoryRoomId, studentIds);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithFreeSpaces(int dormitoryId)
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsWithFreeSpaces(dormitoryId);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsByDormitoryId(int dormitoryId)
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsByDormitoryId(dormitoryId);
        }

        public async Task<IReadOnlyCollection<DormitoryRoom>> GetRoomsWithoutDormitory()
        {
            return await UnitOfWork.DormitoryRoomRepository.GetRoomsWithoutDormitory();
        }
    }
}