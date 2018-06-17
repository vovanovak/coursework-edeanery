using EDeanery.DAL.DAOs;
using EDeanery.Domain.Entities;
using EDeanery.Domain.ValueObjects;
using EDeanery.Mappers.Abstract;

namespace EDeanery.DAL.Mappers
{
    internal class StudentMapper : IMapper<Student, StudentEntity>, IMapper<StudentEntity, Student>
    {
        private readonly IMapper<FacultyEntity, Faculty> _facultyMapper;
        private readonly IMapper<SpecialityEntity, Speciality> _specialityMapper;
        
        public StudentMapper(
            IMapper<FacultyEntity, Faculty> facultyMapper, 
            IMapper<SpecialityEntity, Speciality> specialityMapper)
        {
            _facultyMapper = facultyMapper;
            _specialityMapper = specialityMapper;
        }
        
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
                SpecialityId = entity.StudentTicketInfo.Speciality.SpecialityId,
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
                PassportInfo = new PassportInfo(
                    entity.PassportIdentifier, 
                    entity.FirstName, 
                    entity.LastName, 
                    entity.FathersName, 
                    entity.BirthDate),
                StudentTicketInfo = new StudentTicketInfo(
                    entity.StudentTicketId,
                    _facultyMapper.Map(entity.SpecialityEntity.FacultyEntity), 
                    _specialityMapper.Map(entity.SpecialityEntity),
                    entity.Course, 
                    entity.OnBudget),
                CommunicationInfo = new CommunicationInfo(entity.Email, entity.PhoneNumber)
            };
        }
    }
}