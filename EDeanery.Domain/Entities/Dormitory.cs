using System.Collections.Generic;

namespace EDeanery.Domain.Entities
{
    public class Dormitory
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public int MaxCountOfMembers { get; set; }
        public int CountOfFreeSpaces { get; set; }
        public string Address { get; set; }
        public int NumberOfFlors { get; set; }
        public ICollection<Faculty> MainFaculties { get; set; }
        public ICollection<DormitoryRoom> Rooms { get; set; }

        public Dormitory()
        {
            MainFaculties = new List<Faculty>();
            Rooms = new List<DormitoryRoom>();
        }
    }
}