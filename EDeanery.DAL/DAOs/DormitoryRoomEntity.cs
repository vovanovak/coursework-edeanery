using System.Collections.Generic;

namespace EDeanery.DAL.DAOs
{
    public class DormitoryRoomEntity
    {
        public int DormitoryRoomId { get; set; }
        public string DormitoryRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public int? DormitoryId { get; set; }
        public DormitoryEntity DormitoryEntity { get; set; }
        public ICollection<DormitoryRoomStudentEntity> DormitoryRoomStudents { get; set; }
    }
}