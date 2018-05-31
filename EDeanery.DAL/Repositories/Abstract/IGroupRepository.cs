using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IGroupRepository : IRepository<Group, int>
    {
        Task SetStudentsForGroup(int groupId, IReadOnlyCollection<int> studentIds);
    }
}