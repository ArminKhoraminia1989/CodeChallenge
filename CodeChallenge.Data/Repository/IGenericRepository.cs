using System.Linq.Expressions;

namespace CodeChallenge.Data.Repository.BasicInfo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAll(int take ,int page = 1);
        Task<TEntity> GetById(object id);
        Task<TEntity> FindIdByFilter(Expression<Func<TEntity, bool>> QueryFilter);
        Task<bool> ExistFilter(Expression<Func<TEntity, bool>> QueryFilter);
        Task<int> GetCount(Expression<Func<TEntity, bool>> QueryFilter);
        Task<object> GetMax(Expression<Func<TEntity, bool>> QueryFilter);
        Task<TEntity> CreateAsync(TEntity obj, Expression<Func<TEntity, bool>> QueryFilter);
        Task<TEntity> CreateAsync(TEntity obj);
        Task<bool> UpdateAsync(TEntity obj, Expression<Func<TEntity, bool>> QueryFilter);
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(object id);
        Task<bool> SaveAsync();

    }
}
