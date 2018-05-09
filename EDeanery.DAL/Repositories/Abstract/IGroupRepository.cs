using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IGroupRepository : IRepository<Group, int>
    {
        Task AddStudentAsync(int groupId, int studentId);
        Task DeleteStudentAsync(int groupId, int studentId);
    }
}