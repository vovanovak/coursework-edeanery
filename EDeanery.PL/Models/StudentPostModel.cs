using System;
using System.ComponentModel.DataAnnotations;

namespace EDeanery.PL.Models
{
    public class StudentPostModel
    {
        public int StudentId { get; set; }
        public string IdentificationCode { get; set; }
        public DateTime StartOfLearningDate { get; set; }
        public string PassportIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentTicketId { get; set; }
        public int FacultyId { get; set; }
        public int SpecialityId { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }
    }
}