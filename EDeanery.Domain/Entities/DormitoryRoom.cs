﻿using System.Collections.Generic;

namespace EDeanery.Domain.Entities
{
    public class DormitoryRoom
    {
        public int DormitoryRoomId { get; set; }
        public string DormitoryRoomName { get; set; }
        public int CountOfFreeSpaces { get; set; }
        public int MaxCountInRoom { get; set; }
        public int? DormitoryId { get; set; }
        public string DormitoryName { get; set; }
        public ICollection<Student> Roomers { get; set; }
    }
}