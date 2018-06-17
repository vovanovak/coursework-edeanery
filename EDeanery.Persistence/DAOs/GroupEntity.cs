using System.Collections.Generic;

namespace EDeanery.Persistence.DAOs
{
    public class GroupEntity
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SpecialityId { get; set; }
        public SpecialityEntity SpecialityEntity { get; set; }
        public ICollection<GroupStudentEntity> GroupStudents { get; set; }
    }
}