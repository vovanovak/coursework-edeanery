using EDeanery.BLL.Domain.Entities;
using EDeanery.PL.Models;

namespace EDeanery.PL.Mappers
{
    public interface IStudentMapper
    {
        StudentGetModel Map(Student student);
    }
}