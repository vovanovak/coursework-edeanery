using System.Collections.Generic;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Services.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.DAL.UnitOfWork.Abstract;

namespace EDeanery.BLL.Services
{
    public class StudentService : Service<Student, int>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override IRepository<Student, int> Repository => UnitOfWork.StudentRepository;

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(string search)
        {
            return await UnitOfWork.StudentRepository.GetStudentsByFullName(search);
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search)
        {
            return await UnitOfWork.StudentRepository.GetStudentsByGroup(search);
        }
    }
}