using EDeanery.BLL.Domain.Entities;
using EDeanery.BLL.Domain.ValueObjects;
using EDeanery.DAL.DAOs;
using EDeanery.Mappers.Abstract;

namespace EDeanery.DAL.Mappers
{
    internal class StudentMapper : IMapper<Student, StudentEntity>, IMapper<StudentEntity, Student>
    {
        public StudentEntity Map(Student entity)
        {
            return new StudentEntity
            {
                StudentId = entity.StudentId,
                IdentificationCode = entity.IdentificationCode,
                PassportIdentifier = entity.PassportInfo.PassportIdentifier,
                Email = entity.CommunicationInfo.Email,
                PhoneNumber = entity.CommunicationInfo.PhoneNumber,
                FirstName = entity.PassportInfo.FirstName,
                LastName = entity.PassportInfo.LastName,
                FathersName = entity.PassportInfo.FathersName,
                BirthDate = entity.PassportInfo.BirthDate,
                StudentTicketId = entity.StudentTicketInfo.StudentTicketId,
                FacultyName = entity.StudentTicketInfo.FacultyName,
                SpecialityName = entity.StudentTicketInfo.SpecialityName,
                Course = entity.StudentTicketInfo.Course,
                OnBudget = entity.StudentTicketInfo.OnBudget
            };
        }

        public Student Map(StudentEntity entity)
        {
            return new Student
            {
                StudentId = entity.StudentId,
                IdentificationCode = entity.IdentificationCode,
                StartOfLearningDate = entity.StartOfLearning,
                PassportInfo = new PassportInfo(entity.PassportIdentifier, entity.FirstName, entity.LastName, entity.FathersName, entity.BirthDate),
                StudentTicketInfo = new StudentTicketInfo(entity.StudentTicketId, entity.FacultyName, entity.SpecialityName, entity.Course, entity.OnBudget),
                DormitoryRoom = new DormitoryRoom
                {
                    DormitoryRoomId = entity.DormitoryRoomStudentEntity.DormitoryRoomEntity.DormitoryRoomId,
                    DormityRoomName = entity.DormitoryRoomStudentEntity.DormitoryRoomEntity.DormityRoomName,
                    MaxCountInRoom = entity.DormitoryRoomStudentEntity.DormitoryRoomEntity.MaxCountInRoom
                },
                Group = new Group
                {
                    GroupId = entity.GroupStudentEntity.GroupEntity.GroupId,
                    GroupName = entity.GroupStudentEntity.GroupEntity.GroupName
                }
            };
        }
    }
}