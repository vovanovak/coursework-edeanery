using System.Threading.Tasks;

namespace EDeanery.BLL.Services.Abstract
{
    public interface IService<in TEntity>
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task GetAll();
    }
}