using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDeanery.Host.Models
{
    public class GroupPostModel
    {
        public int GroupId { get; set; }
        
        [Required]
        public string GroupName { get; set; }
        
        [Required]
        public int FacultyId { get; set; }
        
        [Required]
        public int SpecialityId { get; set; }
        public ICollection<int> Students { get; set; }
    }
}