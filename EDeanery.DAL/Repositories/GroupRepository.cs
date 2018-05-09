using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDeanery.DAL.Context.Abstract;
using EDeanery.DAL.DAOs;
using EDeanery.DAL.Mappers.Abstract;
using EDeanery.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Group = EDeanery.BLL.Domain.Entities.Group;

namespace EDeanery.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IEdeaneryDbContext _context;
        private readonly IMapper<Group, DAOs.Group> _groupMapper;
        private readonly IMapper<DAOs.Group, Group> _daoGroupMapper;

        public GroupRepository(
            IEdeaneryDbContext context,
            IMapper<Group, DAOs.Group> GroupMapper,
            IMapper<DAOs.Group, Group> daoGroupMapper)
        {
            _context = context;
            _groupMapper = GroupMapper;
            _daoGroupMapper = daoGroupMapper;
        }

        public async Task AddAsync(Group entity)
        {
            var dao = _groupMapper.Map(entity);
            await _context.Groups.AddAsync(dao);
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
            var groupDaos = await _context.Groups.ToListAsync();
            return groupDaos.Select(d => _daoGroupMapper.Map(d)).ToList();
        }

        public async Task<Group> GetById(int id)
        {
            return _daoGroupMapper.Map(await _context.Groups.SingleOrDefaultAsync(d => d.GroupId == id));
        }

        public async Task AddStudentAsync(int groupId, int studentId)
        {
            await _context.GroupStudents.AddAsync(new GroupStudent
            {
                StudentId = studentId,
                GroupId = groupId
            });
        }

        public async Task DeleteStudentAsync(int groupId, int studentId)
        {
            var groupStudent =
                await _context.GroupStudents.SingleOrDefaultAsync(g =>
                    g.GroupId == groupId && g.StudentId == studentId);

            _context.GroupStudents.Remove(groupStudent);
        }
    }
}