using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Data.SqlClient;


namespace StoreOnline.DAL.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class

    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> entities;

        public BaseRepository (IDbFactory dbFactory)
        {
            this.dbContext = dbFactory.GetDbContext;
            this.entities = this.dbContext.Set<TEntity>();
        }


        public virtual void ExecuteProcedure(string procedureCommand, params SqlParameter[] sqlParams) => this.dbContext.Database.ExecuteSqlRaw(procedureCommand, sqlParams);
        public virtual void Exists(Expression<Func<TEntity, bool>> filter) => this.entities.Any(filter);
        public virtual IEnumerable<TEntity> GetEntities() => this.entities.AsQueryable();

        public IEnumerable<TEntity> GetEntities(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntity(int entityid) => this.entities.Find(entityid);
    
        
        public void Remove(TEntity entity) => this.entities.Remove(entity);

        public void Save(TEntity entity) => this.entities.Add(entity);
        public void Modify(TEntity entity)
        {

            var entry = this.dbContext.Entry(entity);
            this.entities.Attach(entity);
            entry.State = EntityState.Modified;


        }

        bool IBaseRepository<TEntity>.Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
