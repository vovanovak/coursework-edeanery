using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.Application.Services.Abstract;
using EDeanery.Domain.Entities;
using EDeanery.Persistence.Repositories.Abstract;

namespace EDeanery.Application.Services
{
    internal class StudentService : Service<Student, int>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IDormitoryRoomRepository _dormitoryRoomRepository;

        public StudentService(
            IStudentRepository studentRepository,
            IGroupRepository groupRepository,
            IDormitoryRoomRepository dormitoryRoomRepository) : base(studentRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _dormitoryRoomRepository = dormitoryRoomRepository;
        }

        public override async Task<Student> GetById(int id)
        {
            var baseStudent = await base.GetById(id);

            baseStudent.Group = await _groupRepository.GetGroupByStudentId(id);
            baseStudent.DormitoryRoom = await _dormitoryRoomRepository.GetDormitoryRoomByStudentId(id);
            
            return baseStudent;
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(
            string search,
            int? groupId, 
            int? dormitoryId,
            int? dormitoryRoomId)
        {
            return await _studentRepository.GetStudentsByFullName(search, groupId, dormitoryId, dormitoryRoomId);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search, int? groupId, int? dormitoryId, int? dormitoryRoomId)
        {
            return await _studentRepository.GetStudentsByGroup(search, groupId, dormitoryId, dormitoryRoomId);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms()
        {
            return await _studentRepository.GetStudentsWithoutRooms();
        }
    }
}