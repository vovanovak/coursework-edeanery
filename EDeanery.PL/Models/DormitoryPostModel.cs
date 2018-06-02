using System.Collections.Generic;

namespace EDeanery.PL.Models
{
    public class DormitoryPostModel
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfFloors { get; set; }
        public int MaxCountOfMembers { get; set; }
        public ICollection<int> Faculties { get; set; }
        public ICollection<int> DormitoryRooms { get; set; }
    }
}