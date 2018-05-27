using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Domain.ValueObjects;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Models;

namespace EDeanery.PL.Mappers
{
    public class StudentMapper : IMapper<Student, StudentGetModel>, IMapper<StudentPostModel, Student>
    {
        public StudentGetModel Map(Student student)
        {
            return new StudentGetModel
            {
                FullName = string.Join(" ", student.PassportInfo.LastName, student.PassportInfo.FirstName, student.PassportInfo.FathersName),
                IdentificationCode = student.IdentificationCode,
                BirthDate = student.PassportInfo.BirthDate,
                StartOfLearningDate = student.StartOfLearningDate,
                PassportIdentifier = student.PassportInfo.PassportIdentifier,
                StudentTicket = student.StudentTicketInfo.StudentTicketId,
                FacultyName = student.StudentTicketInfo.FacultyName,
                SpecialityName = student.StudentTicketInfo.SpecialityName,
                Course = student.StudentTicketInfo.Course,
                OnBudget = student.StudentTicketInfo.OnBudget,
                GroupName = student.Group.GroupName,
                DormitoryName = student.DormitoryRoom.DormitoryName,
                DormitoryRoomName = student.DormitoryRoom.DormityRoomName
            };
        }

        public Student Map(StudentPostModel entity)
        {
            return new Student
            {
                IdentificationCode = entity.IdentificationCode,
                StudentTicketInfo = new StudentTicketInfo(entity.StudentTicketId, entity.FacultyName, entity.SpecialityName, entity.Course, entity.OnBudget),
                StartOfLearningDate = entity.StartOfLearningDate,
                PassportInfo = new PassportInfo(entity.PassportIdentifier, entity.FirstName, entity.LastName, entity.FathersName, entity.BirthDate)
            };
        }
    }
}