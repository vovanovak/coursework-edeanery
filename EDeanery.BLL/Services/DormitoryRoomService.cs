using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public class DormitoryRoomService : Service<DormitoryRoom, int>, IDormitoryRoomService
    {
        public DormitoryRoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<DormitoryRoom, int> Repository => UnitOfWork.DormitoryRoomRepository;
        public async Task AddStudentAsync(int studentId, int dormitoryRoomId)
        {
            await UnitOfWork.DormitoryRoomRepository.AddStudentAsync(studentId, dormitoryRoomId);
        }

        public async Task DeleteStudentAsync(int studentId, int dormitoryRoomId)
        {
            await UnitOfWork.DormitoryRoomRepository.DeleteStudentAsync(studentId, dormitoryRoomId);
        }
    }
}