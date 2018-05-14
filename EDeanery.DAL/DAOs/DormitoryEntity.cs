using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class DormitoryEntity
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public int MaxCountOfMembers { get; set; }
        public ICollection<DormitoryFacultyEntity> DormitoryFaculties { get; set; }
        public ICollection<DormitoryRoomEntity> DormitoryRooms { get; set; }
    }
}