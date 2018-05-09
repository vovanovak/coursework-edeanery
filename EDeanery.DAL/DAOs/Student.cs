using System;

namespace EDeanery.DAL.DAOs
{
    public class Student
    {
        public int StudentId { get; set; }
        public string IdentificationCode { get; set; }
        public string PassportIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentTickerId { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }
        public Group Group { get; set; }
        public DormitoryRoom DormitoryRoom { get; set; }
    }
}