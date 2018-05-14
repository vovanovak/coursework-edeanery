using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.Mappers.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Student, DAOs.StudentEntity> _studentMapper;
        private readonly IMapper<DAOs.StudentEntity, Student> _daoStudentMapper;

        public StudentRepository(
            IEdeaneryDbContext context,
            IMapper<Student, DAOs.StudentEntity> StudentMapper,
            IMapper<DAOs.StudentEntity, Student> daoStudentMapper)
        {
            _context = context;
            _studentMapper = StudentMapper;
            _daoStudentMapper = daoStudentMapper;
        }

        public async Task AddAsync(Student entity)
        {
            var dao = _studentMapper.Map(entity);
            await _context.Students.AddAsync(dao);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(d => d.StudentId == id);
            _context.Students.Remove(student);
        }

        public void UpdateAsync(Student entity)
        {
            var dao = _studentMapper.Map(entity);
            _context.Students.Update(dao);
        }

        public async Task<ICollection<Student>> GetAll()
        {
            return await _context.Students.Select(d => _daoStudentMapper.Map(d)).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return _daoStudentMapper.Map(await _context.Students.SingleOrDefaultAsync(d => d.StudentId == id));
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(string search)
        {
            var studentDaos = await _context.Students.Where(s =>
                    EF.Functions.Like(s.FirstName, $"%{search}%") || EF.Functions.Like(s.LastName, $"%{search}%"))
                .ToListAsync();
            
            return studentDaos.Select(s => _daoStudentMapper.Map(s)).ToList();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search)
        {
            var studentDaos = await _context.Students.Include(s => s.GroupEntity)
                .Where(s => EF.Functions.Like(s.GroupEntity.GroupName, $"%{search}%")).ToListAsync();

            return studentDaos.Select(s => _daoStudentMapper.Map(s)).ToList();
        }
    }
}