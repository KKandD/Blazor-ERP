using Core.Entities.Base;
using Core.Extensions;
using Core.Interfaces.Base;
using Core.Interfaces.Users;
using Core.Pagination;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        protected readonly ICurrentApplicationUserService _currentApplicationUserService;

        public Repository(IDbContextFactory<AppDbContext> dbContextFactory,
            ICurrentApplicationUserService currentApplicationUserService)
        {
            _dbContextFactory = dbContextFactory;
            _currentApplicationUserService = currentApplicationUserService;
        }

        public async Task<bool> CheckIfExist(int id)
        {
            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                return await _dbContext.Set<TEntity>().AsNoTracking().AnyAsync(prp => prp.Id.Equals(id));
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> GetCountAsync()
        {
            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                return await _dbContext.Set<TEntity>().AsNoTracking().CountAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();

            var query = _dbContext.Set<TEntity>().AsNoTracking();
            query = func != null ? func(query) : query;

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking();

            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                await _dbContext.AddAsync(entity);

                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(AddRangeAsync)} entity must not be null");
            }

            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                foreach (var entity in entities)
                {
                    await _dbContext.AddAsync(entity);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                _dbContext.Update(entity);

                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entity must not be null");
            }

            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                foreach (var entity in entities)
                {
                    _dbContext.Update(entity);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return entities;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                _dbContext.Remove(entity);

                await _dbContext.SaveChangesAsync();

                return;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be delete: {ex.Message}");
            }
        }

        public async Task<TEntity> GetByIdNoTrackingAsync(int id)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();

            return await _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(prp => prp.Id == id);
        }

        public async Task<IPagedList<TEntity>> GetAllPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();

            var query = _dbContext.Set<TEntity>().AsNoTracking();

            query = func != null ? func(query) : query;

            return await query.ToPagedListAsync(pageIndex, pageSize, getOnlyTotalCount);
        }

        public async Task DeleteRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteRangeAsync)} entity must not be null");
            }

            try
            {
                using var _dbContext = _dbContextFactory.CreateDbContext();

                foreach (var entity in entities)
                {
                    _dbContext.Remove(entity);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
