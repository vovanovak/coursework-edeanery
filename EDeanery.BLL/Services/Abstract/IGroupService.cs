using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IGroupService : IService<Group, int>
    {
        Task AddStudentAsync(int groupId, int studentId);
        Task DeleteStudentAsync(int groupId, int studentId);
    }
}