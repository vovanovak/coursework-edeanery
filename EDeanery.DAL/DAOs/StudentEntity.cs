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
        public string StudentTickerId { get; set; }
        public string FacultyName { get; set; }
        public string SpecialityName { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }
        public int GroupId { get; set; }
        public GroupEntity GroupEntity { get; set; }
        public int DormitoryRoomId { get; set; }
        public DormitoryRoomEntity DormitoryRoomEntity { get; set; }
    }
}