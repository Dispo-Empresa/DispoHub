using DispoHub.Core.Domain.Repositories;
using DispoHub.Shared.Domain.Entities;
using DispoHub.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DispoHub.Core.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly DispoHubContext _context;

        public BaseRepository(DispoHubContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public virtual TEntity Create(TEntity obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual IEnumerable<TEntity?> GetAllAsNoTracking()
            => _context.Set<TEntity>()
                       .AsNoTracking()
                       .ToList();

        public virtual TEntity? GetByIdAsNoTracking(long id)
            => _context.Set<TEntity>()
                       .AsNoTracking()
                       .Where(x => x.Id == id)
                       .FirstOrDefault();

        public virtual IEnumerable<TEntity?> GetAll()
            => _context.Set<TEntity>()
                       .ToList();

        public virtual TEntity? GetById(long id)
            => _context.Set<TEntity>()
                       .Where(x => x.Id == id)
                       .FirstOrDefault();

        public virtual IEnumerable<TEntity?> GetByExpression(Expression<Func<TEntity, bool>> expression)
            => _context.Set<TEntity>()
                       .Where(expression);

        public virtual TEntity Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public virtual void Delete(long id)
        {
            var obj = GetById(id);

            if (obj != null)
            {
                _context.Remove(obj);
                _context.SaveChanges();
            }
        }

        public virtual async Task<bool> CreateAsync(TEntity obj)
        {
            await _context.AddAsync(obj);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<TEntity?> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity?>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                                 .ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity?>> GetAllAsNoTrackinAsync()
        {
            return await _context.Set<TEntity>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<bool> UpdateAsync(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(long id)
        {
            var obj = await GetByIdAsync(id);

            if (obj is null)
                return false;

            _context.Remove(obj);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> ExistsByIdAsync(long id)
        {
            return await _context.Set<TEntity>()
                                 .AnyAsync(w => w.Id == id);
        }

        public bool ExistsById(long id)
        {
            return _context.Set<TEntity>()
                           .Any(w => w.Id == id);
        }
    }
}