using System.Linq;
using EDeanery.BLL.Domain.Entities;
using EDeanery.DAL.DAOs;
using Group = EDeanery.BLL.Domain.Entities.Group;


namespace EDeanery.DAL.Mappers.Abstract
{
    public class GroupMapper : IMapper<Group, GroupEntity>, IMapper<GroupEntity, Group>
    {
        private readonly IMapper<SpecialityEntity, Speciality> _specialityMapper;
        private readonly IMapper<StudentEntity, Student> _studentMapper;
        
        public GroupMapper(
            IMapper<SpecialityEntity, Speciality> specialityMapper,
            IMapper<StudentEntity, Student> studentMapper)
        {
            _specialityMapper = specialityMapper;
            _studentMapper = studentMapper;
        }
        
        public GroupEntity Map(Group entity)
        {
            var group = new GroupEntity
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                SpecialityId = entity.Speciality.SpecialityId
            };

            group.GroupStudents = entity.Students.Select(s => new GroupStudentEntity
            {
                GroupId = entity.GroupId,
                StudentId = s.StudentId
            }).ToList();

            return group;
        }

        public Group Map(GroupEntity entity)
        {
            return new Group
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                Speciality = _specialityMapper.Map(entity.SpecialityEntity),
                Students = entity.GroupStudents.Select(s => _studentMapper.Map(s.StudentEntity)).ToList()
            };
        }
    }
}