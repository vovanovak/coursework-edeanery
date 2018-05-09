using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class Dormitory
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public int MaxCountOfMembers { get; set; }
        public ICollection<DormitoryFaculty> DormitoryFaculties { get; set; }
        public ICollection<DormitoryRoom> DormitoryRooms { get; set; }
    }
}