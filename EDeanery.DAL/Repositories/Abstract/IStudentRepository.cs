using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        Task<IReadOnlyCollection<Student>> GetStudentsByFullName(string search);
        Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search);
        Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms();
    }
}