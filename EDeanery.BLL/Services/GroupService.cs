using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    internal class GroupService : Service<Group, int>, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Group, int> Repository => UnitOfWork.GroupRepository;


        public async Task SetStudentsFromGroup(int groupId, IReadOnlyCollection<int> studentIds)
        {
            await UnitOfWork.GroupRepository.SetStudentsForGroup(groupId, studentIds);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}