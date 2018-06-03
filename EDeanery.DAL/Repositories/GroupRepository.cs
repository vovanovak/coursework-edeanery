using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.DAOs;
using EDeanery.DAL.Repositories.Abstract;
using EDeanery.Mappers.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EDeanery.DAL.Repositories
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Group, GroupEntity> _groupMapper;
        private readonly IMapper<GroupEntity, Group> _daoGroupMapper;

        public GroupRepository(
            IEdeaneryDbContext edeaneryDbContext,
            IMapper<Group, GroupEntity> groupMapper,
            IMapper<GroupEntity, Group> daoGroupMapper)
        {
            _context = edeaneryDbContext;
            _groupMapper = groupMapper;

            _daoGroupMapper = daoGroupMapper;
        }

        private IQueryable<GroupEntity> GetGroupsWithIncludes()
        {
            return _context.Groups
                .Include(g => g.GroupStudents)
                .ThenInclude(gs => gs.StudentEntity)
                .ThenInclude(s => s.SpecialityEntity)
                .ThenInclude(s => s.FacultyEntity)
                .Include(g => g.SpecialityEntity)
                .ThenInclude(g => g.FacultyEntity);
        }

        public async Task AddAsync(Group entity)
        {
            var dao = _groupMapper.Map(entity);
            await _context.Groups.AddAsync(dao);
            await _context.SaveChangesAsync();
            entity.GroupId = dao.GroupId;
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(d => d.GroupId == id);
            _context.Groups.Remove(group);
        }

        public void UpdateAsync(Group entity)
        {
            var dao = _groupMapper.Map(entity);
            _context.Groups.Update(dao);
        }

        public async Task<ICollection<Group>> GetAll()
        {
            var groupDaos = await GetGroupsWithIncludes().ToListAsync();
            return groupDaos.Select(d => _daoGroupMapper.Map(d)).ToList();
        }

        public async Task<Group> GetById(int id)
        {
            return _daoGroupMapper.Map(await GetGroupsWithIncludes().SingleOrDefaultAsync(d => d.GroupId == id));
        }

        public async Task SetStudentsForGroup(int groupId, IReadOnlyCollection<int> studentIds)
        {
            var existingGroupStudents = _context.GroupStudents.Where(gs => gs.GroupId == groupId);
            var newGroupStudents = studentIds.Select(studentId => new GroupStudentEntity
            {
                GroupId = groupId,
                StudentId = studentId
            });

            _context.GroupStudents.RemoveRange(existingGroupStudents);
            await _context.GroupStudents.AddRangeAsync(newGroupStudents);
        }

        public async Task<Group> GetGroupByStudentId(int studentId)
        {
            var group = await GetGroupsWithIncludes()
                .FirstOrDefaultAsync(g => g.GroupStudents.Any(gs => gs.StudentId == studentId));

            return group == null ? null : _daoGroupMapper.Map(group);
        }
    }
}