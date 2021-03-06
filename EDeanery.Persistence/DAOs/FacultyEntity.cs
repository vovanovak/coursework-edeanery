﻿using System.Collections.Generic;

namespace EDeanery.Persistence.DAOs
{
    public class FacultyEntity
    {
        public int FacultyId { get; set; }
        public string Name { get; set; }
        
        public ICollection<DormitoryFacultyEntity> DormitoryFaculties { get; set; }
    }
}