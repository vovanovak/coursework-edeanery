using EDeanery.BLL.Domain.Entities;

namespace EDeanery.DAL.Mappers.Abstract
{
    public class StudentMapper : IMapper<Student, DAOs.StudentEntity>, IMapper<DAOs.StudentEntity, Student>
    {
        public DAOs.StudentEntity Map(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Student Map(DAOs.StudentEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}