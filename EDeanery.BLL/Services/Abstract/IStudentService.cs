using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IStudentService : IService<Student, int>
    {
        Task<IReadOnlyCollection<Student>> GetStudentsByFullName(string search);
        Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search);
    }
}