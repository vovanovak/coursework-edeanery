using System;

namespace EDeanery.DAL.DAOs
{
    public class StudentEntity
    {
        public int StudentId { get; set; }
        public string IdentificationCode { get; set; }
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
        public DateTime StartOfLearning { get; set; }
        public int GroupStudentId { get; set; }
        public GroupStudentEntity GroupStudentEntity { get; set; }
        public int DormitoryRoomStudentId { get; set; }
        public DormitoryRoomStudentEntity DormitoryRoomStudentEntity { get; set; }
    }
}