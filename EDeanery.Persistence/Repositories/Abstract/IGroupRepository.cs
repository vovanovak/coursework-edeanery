using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;

namespace EDeanery.Persistence.Repositories.Abstract
{
    public interface IGroupRepository : IRepository<Group, int>
    {
        Task SetStudentsForGroup(int groupId, IReadOnlyCollection<int> studentIds);
        Task<Group> GetGroupByStudentId(int studentId);
        bool IsGroupNameUnique(string name);
    }
}