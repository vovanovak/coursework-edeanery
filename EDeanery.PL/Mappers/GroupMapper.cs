using System.Linq;
using EDeanery.BLL.Domain.Entities;
using EDeanery.Mappers.Abstract;
using EDeanery.Mappers.Extensions;
using EDeanery.PL.Models;

namespace EDeanery.PL.Mappers
{
    public class GroupMapper : 
        IMapper<Group, GroupGetModel>, 
        IMapper<Group, GroupGetDetailedModel>,
        IMapper<GroupPostModel, Group>, 
        IMapper<Group, GroupPostModel>
    {
        private readonly IMapper<Student, StudentGetModel> _studentGetModelMapper;

        public GroupMapper(IMapper<Student, StudentGetModel> studentGetModelMapper)
        {
            _studentGetModelMapper = studentGetModelMapper;
        }
        
        public GroupGetModel Map(Group entity)
        {
            return new GroupGetModel
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                FacultyName = entity.Speciality.Faculty.Name,
                SpecialityName = entity.Speciality.SpecialityName,
            };
        }

        GroupGetDetailedModel IMapper<Group, GroupGetDetailedModel>.Map(Group entity)
        {
            return new GroupGetDetailedModel
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                FacultyName = entity.Speciality.Faculty.Name,
                SpecialityName = entity.Speciality.SpecialityName,
                Students = _studentGetModelMapper.Map(entity.Students).ToList()
            };
        }
        
        public Group Map(GroupPostModel entity)
        {
            return new Group
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                Speciality = new Speciality { SpecialityId = entity.SpecialityId }
            };
        }

        GroupPostModel IMapper<Group, GroupPostModel>.Map(Group entity)
        {
            return new GroupPostModel
            {
                GroupId = entity.GroupId,
                GroupName = entity.GroupName,
                SpecialityId = entity.Speciality.SpecialityId,
                Students = _studentGetModelMapper
                    .Map(entity.Students)
                    .Select(s => s.StudentId)
                    .ToList()
            };
        }
    }
}