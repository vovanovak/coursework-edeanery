using System.Threading.Tasks;

namespace EDeanery.Host.Providers
{
    public interface IViewBagDataProvider
    {
        Task InitFaculties(dynamic viewBag);
        Task InitSpecialities(dynamic viewBag, int facultyId);
        Task InitFacultiesAndSpecialities(dynamic viewBag);
    }
}