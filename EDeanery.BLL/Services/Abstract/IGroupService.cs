using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IGroupService : IService<Group, int>
    {
        Task SetStudentsFromGroup(int groudId, IReadOnlyCollection<int> studentIds);
    }
}