using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;
using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services
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

        public bool IsGroupNameUnique(string name)
        {
            return UnitOfWork.GroupRepository.IsGroupNameUnique(name);
        }
    }
}