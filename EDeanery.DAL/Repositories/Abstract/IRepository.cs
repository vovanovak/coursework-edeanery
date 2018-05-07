using System.Threading.Tasks;

namespace EDeanery.DAL.Repositories.Abstract
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task GetAll();
    }
}