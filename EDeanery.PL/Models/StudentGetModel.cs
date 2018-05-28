﻿using System;
using EDeanery.PL.Converters;
using Newtonsoft.Json;

namespace EDeanery.PL.Models
{
    public class StudentGetModel
    {
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