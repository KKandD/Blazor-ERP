using Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<bool> CheckIfExist(int id);
        Task<int> GetCountAsync();
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(List<TEntity> entities);
        Task<TEntity> GetByIdNoTrackingAsync(int id);
        Task<IPagedList<TEntity>> GetAllPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
    }
}
