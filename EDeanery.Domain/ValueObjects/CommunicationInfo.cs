namespace EDeanery.Domain.ValueObjects
{
    public class CommunicationInfo
    {
        public CommunicationInfo(string email, string phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}