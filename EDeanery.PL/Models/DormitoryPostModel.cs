﻿using System.Collections.Generic;

namespace EDeanery.PL.Models
{
    public class DormitoryPostModel
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfFlors { get; set; }
        public int MaxCountOfMembers { get; set; }
        public string Faculties { get; set; }
        public ICollection<int> DormitoryRooms { get; set; }
    }
}