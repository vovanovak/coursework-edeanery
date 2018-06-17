using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.Persistence.Context.Abstract;
using EDeanery.Persistence.DAOs;
using EDeanery.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.Persistence.Repositories
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
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            var dao = _studentMapper.Map(entity);
            _context.Students.Update(dao);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Student>> GetAll()
        {
            return await GetStudentsWithIncludes().Select(d => _daoStudentMapper.Map(d)).ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return _daoStudentMapper.Map(await GetStudentsWithIncludes().SingleOrDefaultAsync(d => d.StudentId == id));
        }

        private List<StudentEntity> FilterByGroup(List<StudentEntity> studentDaos, int? groupId)
        {
            if (groupId.HasValue)
            {
                var studentIds = _context.GroupStudents
                    .Where(g => g.GroupId == groupId.Value)
                    .Select(s => s.StudentId)
                    .ToList();

                studentDaos = studentDaos.Where(s => studentIds.Contains(s.StudentId)).ToList();
            }

            return studentDaos;
        }
        
        private List<StudentEntity> FilterByDormitory(List<StudentEntity> studentDaos, int? dormitoryId)
        {
            if (dormitoryId.HasValue)
            {
                var studentIds = _context.DormitoryRoomStudents
                    .Include(drs => drs.DormitoryRoomEntity)
                    .Include(drs => drs.StudentEntity)
                    .Where(drs => drs.DormitoryRoomEntity.DormitoryId == dormitoryId.Value)
                    .Select(drs => drs.StudentEntity.StudentId).ToList();
                
                studentDaos = studentDaos.Where(s => studentIds.Contains(s.StudentId)).ToList();
            }

            return studentDaos;
        }
        
        private List<StudentEntity> FilterByDormitoryRoom(List<StudentEntity> studentDaos, int? dormitoryRoomId)
        {
            if (dormitoryRoomId.HasValue)
            {
                var studentIds = _context.DormitoryRoomStudents
                    .Include(drs => drs.DormitoryRoomEntity)
                    .Include(drs => drs.StudentEntity)
                    .Where(drs => drs.DormitoryRoomEntity.DormitoryRoomId == dormitoryRoomId.Value)
                    .Select(drs => drs.StudentEntity.StudentId).ToList();
                
                studentDaos = studentDaos.Where(s => studentIds.Contains(s.StudentId)).ToList();
            }

            return studentDaos;
        }

        private async Task SetSpecialities(List<StudentEntity> studentDaos)
        {
            var distinctSpecialityIds = studentDaos.Select(s => s.SpecialityId).Distinct().ToList();

            var specialities = await _context.Specialities
                .Include(s => s.FacultyEntity)
                .Where(s => distinctSpecialityIds.Contains(s.SpecialityId))
                .ToDictionaryAsync(s => s.SpecialityId, s => s);

            foreach (var student in studentDaos)
            {
                student.SpecialityEntity = specialities[student.SpecialityId];
            }
            
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(
            string search, 
            int? groupId, 
            int? dormitoryId,
            int? dormitoryRoomId)
        {
            var studentDaos = await GetStudentsWithIncludes().Where(s =>
                    EF.Functions.Like(s.FirstName, $"%{search}%") || EF.Functions.Like(s.LastName, $"%{search}%"))
                .ToListAsync();

            studentDaos = FilterByGroup(studentDaos, groupId);
            studentDaos = FilterByDormitory(studentDaos, dormitoryId);
            studentDaos = FilterByDormitoryRoom(studentDaos, dormitoryRoomId);
            
            await SetSpecialities(studentDaos);
   
            return studentDaos.Select(_daoStudentMapper.Map).ToList();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(
            string search,
            int? groupId, 
            int? dormitoryId,
            int? dormitoryRoomId)
        {
            var studentDaos = await _context.Groups.Include(g => g.GroupStudents)
                .ThenInclude(g => g.StudentEntity)
                .Where(g => EF.Functions.Like(g.GroupName, $"%{search}%"))
                .SelectMany(g => g.GroupStudents).Select(g => g.StudentEntity)
                .ToListAsync();

            studentDaos = FilterByGroup(studentDaos, groupId);
            studentDaos = FilterByDormitory(studentDaos, dormitoryId);
            studentDaos = FilterByDormitoryRoom(studentDaos, dormitoryRoomId);

            await SetSpecialities(studentDaos);
            
            return _daoStudentMapper.Map(studentDaos).ToList();
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