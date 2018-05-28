using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class SpecialityEntity
    {
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public int FacultyId { get; set; }
        public FacultyEntity FacultyEntity { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
    }
}