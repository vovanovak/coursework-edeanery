using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    internal class StudentRepository : Repository<Student, StudentEntity, int>, IStudentRepository
    {
        public StudentRepository(
            IEdeaneryDbContext context,
            IMapper<Student, StudentEntity> studentMapper,
            IMapper<StudentEntity, Student> daoStudentMapper)
            : base(context, studentMapper, daoStudentMapper)
        {
        }

        private List<StudentEntity> FilterByGroup(List<StudentEntity> studentDaos, int? groupId)
        {
            if (groupId.HasValue)
            {
                var studentIds = Context.GroupStudents
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
                var studentIds = Context.DormitoryRoomStudents
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
                var studentIds = Context.DormitoryRoomStudents
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

            var specialities = await Context.Specialities
                .Include(s => s.FacultyEntity)
                .Where(s => distinctSpecialityIds.Contains(s.SpecialityId))
                .ToDictionaryAsync(s => s.SpecialityId, s => s);

            foreach (var student in studentDaos)
            {
                student.SpecialityEntity = specialities[student.SpecialityId];
            }

            await Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByFullName(
            string search,
            int? groupId,
            int? dormitoryId,
            int? dormitoryRoomId)
        {
            var studentDaos = await GetWithAllIncludes().Where(s =>
                    EF.Functions.Like(s.FirstName, $"%{search}%") || EF.Functions.Like(s.LastName, $"%{search}%"))
                .ToListAsync();

            studentDaos = FilterByGroup(studentDaos, groupId);
            studentDaos = FilterByDormitory(studentDaos, dormitoryId);
            studentDaos = FilterByDormitoryRoom(studentDaos, dormitoryRoomId);

            await SetSpecialities(studentDaos);

            return EntityMapper.Map(studentDaos).ToList();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsByGroup(
            string search,
            int? groupId,
            int? dormitoryId,
            int? dormitoryRoomId)
        {
            var studentDaos = await Context.Groups.Include(g => g.GroupStudents)
                .ThenInclude(g => g.StudentEntity)
                .Where(g => EF.Functions.Like(g.GroupName, $"%{search}%"))
                .SelectMany(g => g.GroupStudents).Select(g => g.StudentEntity)
                .ToListAsync();

            studentDaos = FilterByGroup(studentDaos, groupId);
            studentDaos = FilterByDormitory(studentDaos, dormitoryId);
            studentDaos = FilterByDormitoryRoom(studentDaos, dormitoryRoomId);

            await SetSpecialities(studentDaos);

            return EntityMapper.Map(studentDaos).ToList();
        }

        public async Task<IReadOnlyCollection<Student>> GetStudentsWithoutRooms()
        {
            var studentDaos = await GetWithAllIncludes()
                .Where(s => !Context.DormitoryRoomStudents.Any(dr => dr.StudentId == s.StudentId))
                .ToListAsync();

            return EntityMapper.Map(studentDaos).ToList();
        }

        protected override DbSet<StudentEntity> Table => Context.Students;

        protected override IQueryable<StudentEntity> GetWithAllIncludes()
        {
            return Context.Students
                .Include(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity);
        }

        protected override Expression<Func<StudentEntity, bool>> GetDaoById(int id)
        {
            return student => student.StudentId == id;
        }

        protected override void SetId(Student entity, StudentEntity dao)
        {
            entity.StudentId = dao.StudentId;
        }
    }
}