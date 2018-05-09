using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public Speciality Speciality { get; set; }
        public ICollection<GroupStudent> GroupStudents { get; set; }
    }
}