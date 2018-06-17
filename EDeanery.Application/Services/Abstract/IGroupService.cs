using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;

namespace EDeanery.Application.Services.Abstract
{
    public interface IGroupService : IService<Group, int>
    {
        Task SetStudentsFromGroup(int groudId, IReadOnlyCollection<int> studentIds);
        bool IsGroupNameUnique(string name);
    }
}