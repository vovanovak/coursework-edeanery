using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IGroupService : IService<Group, int>
    {
        Task AddStudentAsync(Group group, Student student);
        Task DeleteStudentAsync(Group group, Student student);
    }
}