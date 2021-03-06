﻿using System;
using EDeanery.Domain.ValueObjects;

namespace EDeanery.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string IdentificationCode { get; set; }
        public DateTime StartOfLearningDate { get; set; }
        public CommunicationInfo CommunicationInfo { get; set; }
        public PassportInfo PassportInfo { get; set; }
        public StudentTicketInfo StudentTicketInfo { get; set; }
        public Group Group { get; set; }
        public DormitoryRoom DormitoryRoom { get; set; }
    }
}