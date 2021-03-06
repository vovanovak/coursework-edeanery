﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDeanery.Host.Models
{
    public class DormitoryPostModel
    {
        public int DormitoryId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        public int NumberOfFloors { get; set; }
        public int MaxCountOfMembers { get; set; }
        
        [Required]
        public ICollection<int> Faculties { get; set; }
        
        [Required]
        public ICollection<int> DormitoryRooms { get; set; }
    }
}