using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boilerplate.Data.Interfaces.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");

        TEntity GetById(object id);

        Task<TEntity> GetByIdAsync(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}