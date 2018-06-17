using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal class GroupService : Service<Group, int>, IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository) : base(groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task SetStudentsFromGroup(int groupId, IReadOnlyCollection<int> studentIds)
        {
            await _groupRepository.SetStudentsForGroup(groupId, studentIds);
        }

        public bool IsGroupNameUnique(string name)
        {
            return _groupRepository.IsGroupNameUnique(name);
        }
    }
}