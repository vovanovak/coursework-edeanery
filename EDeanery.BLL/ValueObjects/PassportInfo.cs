using System;

namespace EDeanery.BLL.ValueObjects
{
    public struct PassportInfo
    {
        public string PassportIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public DateTime BirthDate { get; set; }

        public PassportInfo(
            string passportIdentifier,
            string firstName,
            string lastName,
            string fathersName,
            DateTime birthDate)
        {
            PassportIdentifier = passportIdentifier;
            FirstName = firstName;
            LastName = lastName;
            FathersName = fathersName;
            BirthDate = birthDate;
        }
    }
}