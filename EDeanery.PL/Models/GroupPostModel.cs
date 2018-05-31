using System.Collections.Generic;

namespace EDeanery.PL.Models
{
    public class GroupPostModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int FacultyId { get; set; }
        public int SpecialityId { get; set; }
        public ICollection<int> Students { get; set; }
    }
}