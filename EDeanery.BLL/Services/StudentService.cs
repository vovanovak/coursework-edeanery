using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    internal class StudentService : Service<Student, int>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Student, int> Repository => UnitOfWork.StudentRepository;

        public override async Task<Student> GetById(int id)
        {
            var baseStudent = await base.GetById(id);

            baseStudent.Group = await UnitOfWork.GroupRepository.GetGroupByStudentId(id);
            baseStudent.DormitoryRoom = await UnitOfWork.DormitoryRoomRepository.GetDormitoryRoomByStudentId(id);
            
            return baseStudent;
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(string search)
        {
            return await UnitOfWork.StudentRepository.GetStudentsByFullName(search);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search)
        {
            return await UnitOfWork.StudentRepository.GetStudentsByGroup(search);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms()
        {
            return await UnitOfWork.StudentRepository.GetStudentsWithoutRooms();
        }
    }
}