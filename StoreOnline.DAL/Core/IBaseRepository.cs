using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StoreOnline.DAL.Core
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(int entityId);
        IEnumerable<TEntity> GetEntities();
        void Save(TEntity entity);
        void Modify(TEntity entity);
        void Remove(TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter);
    }
}
