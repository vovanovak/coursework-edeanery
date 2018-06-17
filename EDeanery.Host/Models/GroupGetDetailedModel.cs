using System.Collections.Generic;

namespace EDeanery.Host.Models
{
    public class GroupGetDetailedModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public IReadOnlyCollection<StudentGetModel> Students { get; set; }
    }
}