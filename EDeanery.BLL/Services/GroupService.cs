using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public class GroupService : Service<Group, int>, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Group, int> Repository => UnitOfWork.GroupRepository;

        public async Task AddStudentAsync(int groupId, int studentId)
        {
            await UnitOfWork.GroupRepository.AddStudentAsync(groupId, studentId);
        }

        public async Task DeleteStudentAsync(int groupId, int studentId)
        {
            await UnitOfWork.GroupRepository.DeleteStudentAsync(groupId, studentId);
        }
    }
}