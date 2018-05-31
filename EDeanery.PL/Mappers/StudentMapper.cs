using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Domain.ValueObjects;
using EDeanery.Mappers.Abstract;
using EDeanery.PL.Models;

namespace EDeanery.PL.Mappers
{
    public class StudentMapper : 
        IMapper<Student, StudentGetModel>,
        IMapper<Student, StudentGetDetailedModel>,
        IMapper<StudentPostModel, Student>,
        IMapper<Student, StudentPostModel>,
        IMapper<Student, StudentSelectModel>
    {
        public StudentGetModel Map(Student student)
        {
            return new StudentGetModel
            {
                StudentId = student.StudentId,
                FullName = string.Join(" ", student.PassportInfo.LastName, student.PassportInfo.FirstName, student.PassportInfo.FathersName),
                IdentificationCode = student.IdentificationCode,
                BirthDate = student.PassportInfo.BirthDate,
                PassportIdentifier = student.PassportInfo.PassportIdentifier,
                StudentTicket = student.StudentTicketInfo.StudentTicketId,
                FacultyName = student.StudentTicketInfo.Faculty.Name,
                Email = student.CommunicationInfo.Email,
                PhoneNumber = student.CommunicationInfo.PhoneNumber
            };
        }

        public Student Map(StudentPostModel entity)
        {
            return new Student
            {
                StudentId = entity.StudentId,
                IdentificationCode = entity.IdentificationCode,
                StudentTicketInfo = new StudentTicketInfo(entity.StudentTicketId, new Faculty { FacultyId = entity.FacultyId }, new Speciality { SpecialityId = entity.SpecialityId }, entity.Course, entity.OnBudget),
                StartOfLearningDate = entity.StartOfLearningDate,
                CommunicationInfo = new CommunicationInfo(entity.Email, entity.PhoneNumber),
                PassportInfo = new PassportInfo(entity.PassportIdentifier, entity.FirstName, entity.LastName, entity.FathersName, entity.BirthDate)
            };
        }

        StudentGetDetailedModel IMapper<Student, StudentGetDetailedModel>.Map(Student student)
        {
            return new StudentGetDetailedModel
            {
                StudentId = student.StudentId,
                FullName = string.Join(" ", 
                    student.PassportInfo.LastName, 
                    student.PassportInfo.FirstName,
                    student.PassportInfo.FathersName),
                IdentificationCode = student.IdentificationCode,
                BirthDate = student.PassportInfo.BirthDate,
                StartOfLearningDate = student.StartOfLearningDate,
                PassportIdentifier = student.PassportInfo.PassportIdentifier,
                StudentTicket = student.StudentTicketInfo.StudentTicketId,
                FacultyName = student.StudentTicketInfo.Faculty.Name,
                SpecialityName = student.StudentTicketInfo.Speciality.SpecialityName,
                Course = student.StudentTicketInfo.Course,
                OnBudget = student.StudentTicketInfo.OnBudget,
                GroupName = student.Group?.GroupName,
                DormitoryName = student.DormitoryRoom?.DormitoryName,
                DormitoryRoomName = student.DormitoryRoom?.DormityRoomName,
                Email = student.CommunicationInfo.Email,
                PhoneNumber = student.CommunicationInfo.PhoneNumber
            };
        }

        StudentPostModel IMapper<Student, StudentPostModel>.Map(Student student)
        {
            return new StudentPostModel
            {
                StudentId = student.StudentId,
                IdentificationCode = student.IdentificationCode,
                LastName = student.PassportInfo.LastName,
                FirstName = student.PassportInfo.FirstName,
                FathersName = student.PassportInfo.FathersName,
                BirthDate = student.PassportInfo.BirthDate,
                StartOfLearningDate = student.StartOfLearningDate,
                PassportIdentifier = student.PassportInfo.PassportIdentifier,
                StudentTicketId = student.StudentTicketInfo.StudentTicketId,
                FacultyId = student.StudentTicketInfo.Faculty.FacultyId,
                SpecialityId = student.StudentTicketInfo.Speciality.SpecialityId,
                Course = student.StudentTicketInfo.Course,
                OnBudget = student.StudentTicketInfo.OnBudget,
                Email = student.CommunicationInfo.Email,
                PhoneNumber = student.CommunicationInfo.PhoneNumber 
            };
        }

        StudentSelectModel IMapper<Student, StudentSelectModel>.Map(Student entity)
        {
            return new StudentSelectModel(false, Map(entity));
        }
    }
}