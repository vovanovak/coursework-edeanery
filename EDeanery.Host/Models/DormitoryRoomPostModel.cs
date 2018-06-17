using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDeanery.Host.Models
{
    public class DormitoryRoomPostModel
    {
        public int DormitoryRoomId { get; set; }
        
        [Required]
        public string DormitoryRoomName { get; set; }
        
        [Required]
        public int MaxCountInRoom { get; set; }
        public int DormitoryId { get; set; }
        public ICollection<int> Students { get; set; }
    }
}