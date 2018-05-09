using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        
        public ICollection<DormitoryFaculty> DormitoryFaculties { get; set; }
    }
}