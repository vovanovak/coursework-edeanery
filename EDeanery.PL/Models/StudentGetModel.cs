using System;

namespace EDeanery.PL.Models
{
    public class StudentGetModel
    {
        public string FullName { get; set; }
        public string IdentificationCode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartOfLearningDate { get; set; }
        public string PassportIdentifier { get; set; }
        public string StudentTicket { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }
        public string GroupName { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryRoomName { get; set; } 
    }
}