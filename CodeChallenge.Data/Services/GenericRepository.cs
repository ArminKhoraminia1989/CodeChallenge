using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CodeChallenge.Data.Resources;

namespace CodeChallenge.Application.Services.BasicInfo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private CodeChallengeDBContext _context;
        private CodeChallengeDBContext _readContext;
        private DbSet<TEntity> _table;
        private DbSet<TEntity> _readTable;

        public GenericRepository(CodeChallengeDBContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
            _readContext = context;
            _readContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _readTable = _readContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll(int take, int page)
        {
            try
            {
                if (!(take == null || take == 0))
                {
                    if (page == 0) page = 1;
                    int skip = (page - 1) * take;
                    IQueryable<TEntity> list = _readTable;

                    if ((list.Count() % take) == 0)
                        page = list.Count() / take;
                    else
                        page = (list.Count() / take) + 1;

                    return list.Skip(skip).Take(take).ToList();
                }
                else
                {
                    throw new SystemException(ErrorResource.NotFillParameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetById(object id)
        {
            try
            {
                if ((int)id != 0)
                    return _readTable.Find(id);
                else
                    throw new SystemException(ErrorResource.NotExist);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TEntity> FindIdByFilter(Expression<Func<TEntity, bool>> QueryFilter)
        {
            try
            {
                var exist = _table.FirstOrDefault(QueryFilter);
                //if (exist == null) throw new SystemException(ErrorResource.NotExist);
                return exist;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ExistFilter(Expression<Func<TEntity, bool>> QueryFilter)
        {
            try
            {
                var exist = _table.Any(QueryFilter);
                return exist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetCount(Expression<Func<TEntity, bool>> QueryFilter)
        {
            try
            {
                return _table.Count(QueryFilter);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<object> GetMax(Expression<Func<TEntity, bool>> QueryFilter)
        {
            try
            {
                return _table.Max(QueryFilter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> CreateAsync(TEntity obj, Expression<Func<TEntity, bool>> QueryFilter)
        {
            try
            {
                bool exist = _table.Any(QueryFilter);
                if (exist) throw new SystemException(ErrorResource.EarlyExist);

                _table.Add(obj);
                await SaveAsync();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TEntity> CreateAsync(TEntity obj)
        {
            try
            {
                _table.Add(obj);
                await SaveAsync();
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(TEntity obj, Expression<Func<TEntity, bool>> QueryFilter)
        {
            try
            {
                bool exist = _table.Any(QueryFilter);

                if (exist)
                {
                    throw new NotImplementedException(ErrorResource.NotExist);
                }

                _table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(TEntity obj)
        {
            try
            {
                _table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
                return await SaveAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                var existing = _table.Find(id);
                if (existing != null)
                {
                    _table.Remove(existing);
                    return await SaveAsync();
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
