using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.DAOs;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Student, StudentEntity> _studentMapper;
        private readonly IMapper<StudentEntity, Student> _daoStudentMapper;

        public StudentRepository(
            IEdeaneryDbContext context,
            IMapper<Student, StudentEntity> studentMapper,
            IMapper<StudentEntity, Student> daoStudentMapper)
        {
            _context = context;
            _studentMapper = studentMapper;
            _daoStudentMapper = daoStudentMapper;
        }

        public async Task AddAsync(Student entity)
        {
            var dao = _studentMapper.Map(entity);
            await _context.Students.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.StudentId = dao.StudentId;
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
            return await GetStudentsWithIncludes().Select(d => _daoStudentMapper.Map(d)).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return _daoStudentMapper.Map(await GetStudentsWithIncludes().SingleOrDefaultAsync(d => d.StudentId == id));
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(string search)
        {
            var studentDaos = await GetStudentsWithIncludes().Where(s =>
                    EF.Functions.Like(s.FirstName, $"%{search}%") || EF.Functions.Like(s.LastName, $"%{search}%"))
                .ToListAsync();
            
            return studentDaos.Select(_daoStudentMapper.Map).ToList();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(string search)
        {
            var students = await _context.Groups.Include(g => g.GroupStudents)
                .ThenInclude(g => g.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity)
                .Where(g => EF.Functions.Like(g.GroupName, $"%{search}%"))
                .SelectMany(g => g.GroupStudents).Select(g => g.StudentEntity)
                .ToListAsync();

            return _daoStudentMapper.Map(students).ToList();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms()
        {
            var studentDaos = await GetStudentsWithIncludes()
                .Where(s => !_context.DormitoryRoomStudents.Any(dr => dr.StudentId == s.StudentId))
                .ToListAsync();

            return _daoStudentMapper.Map(studentDaos).ToList();
        }

        private IQueryable<StudentEntity> GetStudentsWithIncludes()
        {
            return _context.Students
                .Include(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }
    }
}