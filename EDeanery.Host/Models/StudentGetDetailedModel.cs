using System;
using EDeanery.Host.Converters;
using Newtonsoft.Json;

namespace EDeanery.Host.Models
{
    public class StudentGetDetailedModel
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationCode { get; set; }

        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime BirthDate { get; set; }

        [JsonConverter(typeof(CustomDateConverter))]
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