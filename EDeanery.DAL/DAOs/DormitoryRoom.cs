using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class DormitoryRoom
    {
        public int DormitoryRoomId { get; set; }
        public string DormityRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public ICollection<DormitoryRoomStudent> DormitoryRoomStudents { get; set; }
    }
}