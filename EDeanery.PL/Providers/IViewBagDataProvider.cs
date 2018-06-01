using System.Threading.Tasks;

namespace EDeanery.PL.Providers
{
    public interface IViewBagDataProvider
    {
        Task InitFaculties(dynamic viewBag);
        Task InitSpecialities(dynamic viewBag, int facultyId);
        Task InitFacultiesAndSpecialities(dynamic viewBag);
    }
}