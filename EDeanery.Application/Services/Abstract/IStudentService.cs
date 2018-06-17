using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.Application.Services.Abstract
{
    public interface IStudentService : IService<Student, int>
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