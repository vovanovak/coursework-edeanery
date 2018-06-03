using System.Collections.Generic;

namespace EDeanery.PL.Models
{
    public class DormitoryRoomPostModel
    {
        public int DormitoryRoomId { get; set; }
        public string DormitoryRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public int DormitoryId { get; set; }
        public ICollection<int> Students { get; set; }
    }
}