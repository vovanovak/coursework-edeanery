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

        public Task AddStudentAsync(Group @group, Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteStudentAsync(Group @group, Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}