using System.Collections.Generic;

namespace EDeanery.Persistence.DAOs
{
    public class DormitoryEntity
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfFlors { get; set; }
        public int MaxCountOfMembers { get; set; }
        public ICollection<DormitoryFacultyEntity> DormitoryFaculties { get; set; }
        public ICollection<DormitoryRoomEntity> DormitoryRooms { get; set; }
    }
}