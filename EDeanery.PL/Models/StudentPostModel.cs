using System;
using System.ComponentModel.DataAnnotations;

namespace EDeanery.PL.Models
{
    public class StudentPostModel
    {
        public int StudentId { get; set; }
        
        [Required]
        public string IdentificationCode { get; set; }
        public DateTime StartOfLearningDate { get; set; }
        
        [Required]
        public string PassportIdentifier { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string FathersName { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string StudentTicketId { get; set; }
        
        [Required]
        public int FacultyId { get; set; }
        
        [Required]
        public int SpecialityId { get; set; }
        
        [Required]
        public int Course { get; set; }
        
        [Required]
        public bool OnBudget { get; set; }
    }
}