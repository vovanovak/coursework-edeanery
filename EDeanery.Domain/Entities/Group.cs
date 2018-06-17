using System.Collections.Generic;

namespace EDeanery.Domain.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public Speciality Speciality { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}