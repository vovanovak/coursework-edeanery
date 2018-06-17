using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDeanery.Application.Services.Abstract
{
    public interface IService<TEntity, in TIdentity>
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TIdentity id);
        Task UpdateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetById(TIdentity id);
    }
}