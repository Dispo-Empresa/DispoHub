using DispoHub.Core.Domain.Entities;
using System.Linq.Expressions;

namespace DispoHub.Core.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Base
    {
        TEntity Create(TEntity obj);

        TEntity? GetById(long id);

        IEnumerable<TEntity?> GetAll();

        IEnumerable<TEntity?> GetAllAsNoTracking();

        IEnumerable<TEntity?> GetByExpression(Expression<Func<TEntity, bool>> expression);

        TEntity Update(TEntity obj);

        void Delete(long id);

        bool ExistsById(long id);

        Task<bool> CreateAsync(TEntity obj);

        Task<TEntity?> GetByIdAsync(long id);

        Task<IEnumerable<TEntity?>> GetAllAsync();

        Task<IEnumerable<TEntity?>> GetAllAsNoTrackinAsync();

        Task<bool> UpdateAsync(TEntity obj);

        Task<bool> DeleteAsync(long id);

        Task<bool> ExistsByIdAsync(long id);
    }
}