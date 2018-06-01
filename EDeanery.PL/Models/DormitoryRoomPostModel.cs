using System.Collections.Generic;

namespace EDeanery.PL.Models
{
    public class DormitoryRoomPostModel
    {
        public int DormitoryRoomId { get; set; }
        public string DormityRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public int DormitoryId { get; set; }
        public IReadOnlyCollection<StudentSelectModel> Students { get; set; }
    }
}