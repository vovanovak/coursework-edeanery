using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        Task<IReadOnlyCollection<Student>> GetStudentsByFullName(
            string search, 
            int? groupId, 
            int? dormitoryId,
            int? dormitoryRoomId);
        Task<IReadOnlyCollection<Student>> GetStudentsByGroup(
            string search,
            int? groupId,
            int? dormitoryId,
            int? dormitoryRoomId);
        Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms();
    }
}