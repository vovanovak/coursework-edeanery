using EDeanery.Domain.Entities;

namespace EDeanery.Domain.ValueObjects
{
    public class StudentTicketInfo
    {
        public string StudentTicketId { get; set; }
        public Faculty Faculty { get; set; }
        public Speciality Speciality { get; set; }
        public int Course { get; set; }
        public bool OnBudget { get; set; }

        public StudentTicketInfo(
            string studentTicketId,
            Faculty faculty,
            Speciality speciality,
            int course,
            bool onBudget)
        {
            StudentTicketId = studentTicketId;
            Faculty = faculty;
            Speciality = speciality;
            Course = course;
            OnBudget = onBudget;
        }
    }
}