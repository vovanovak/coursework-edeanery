using System.Collections.Generic;

namespace EDeanery.BLL.Entities
{
    public class Dormitory
    {
        public int DormitoryId { get; set; }
        public string Name { get; set; }
        public int MaxCountOfMembers { get; set; }
        public ICollection<Faculty> MainFaculties { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}