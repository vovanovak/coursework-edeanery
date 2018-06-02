using System.Collections.Generic;

namespace EDeanery.BLL.Domain.Entities
{
    public class DormitoryRoom
    {
        public int DormitoryRoomId { get; set; }
        public string DormityRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public int? DormitoryId { get; set; }
        public string DormitoryName { get; set; }
        public ICollection<Student> Roomers { get; set; }
    }
}