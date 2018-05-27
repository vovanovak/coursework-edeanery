using System;
using System.ComponentModel.DataAnnotations;

namespace EDeanery.PL.Models
{
    public class StudentPostModel
    {
        public string IdentificationCode { get; set; }
        public DateTime StartOfLearningDate { get; set; }
        public string PassportIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentTicketId { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }
        public string GroupName { get; set; }
        public int DormitoryId { get; set; }
        public int DormitoryRoomId { get; set; }
    }
}