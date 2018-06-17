using System;
using EDeanery.Host.Converters;
using Newtonsoft.Json;

namespace EDeanery.Host.Models
{
    public class StudentGetModel
    {
        public StudentGetModel()
        {
        }

        public StudentGetModel(StudentGetModel studentGetModel)
        {
            StudentId = studentGetModel.StudentId;
            FullName = studentGetModel.FullName;
            Email = studentGetModel.Email;
            PhoneNumber = studentGetModel.PhoneNumber;
            IdentificationCode = studentGetModel.IdentificationCode;
            BirthDate = studentGetModel.BirthDate;
            PassportIdentifier = studentGetModel.PassportIdentifier;
            StudentTicket = studentGetModel.StudentTicket;
            FacultyName = studentGetModel.FacultyName;
        }

        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationCode { get; set; }

        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime BirthDate { get; set; }

        public string PassportIdentifier { get; set; }
        public string StudentTicket { get; set; }
        public string FacultyName { get; set; }
    }
}