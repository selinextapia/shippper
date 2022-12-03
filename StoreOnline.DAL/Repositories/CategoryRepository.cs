using Microsoft.Extensions.Logging;
using StoreOnline.DAL.Context;
using StoreOnline.DAL.Entities;
using StoreOnline.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;


namespace StoreOnline.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreOnlineContext context;
        private readonly ILogger<StoreOnlineContext> looger;

        public CategoryRepository(StoreOnlineContext context, ILogger<StoreOnlineContext> looger)
        {
            this.context = context;
            this.looger = looger;
        }
        public bool Exists(Expression<Func<Category, bool>> filter)
        {
            return this.context.Categories.Any(filter);
        }

        public IEnumerable<Category> GetEntities()
        {
            return this.context.Categories;
        }

        public IEnumerable<Category> GetEntities(Expression<Func<Category, bool>> filter)
        {
            return this.context.Categories.Where(filter);
        }

        public Category GetEntity(int entityId)
        {
            return this.context.Categories.Find(entityId);
        }

        public void Modify(Category entity)
        {
            try
            {
                this.context.Categories.Update(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.looger.LogError($"Error modificando la categoria. { ex.Message } ", ex.ToString());
            }
        }

        public void Remove(Category entity)
        {
            try
            {
                this.context.Categories.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.looger.LogError($"Error eliminando la categoria. {ex.Message} ", ex.ToString());
            }

        }

        public void Save(Category entity)
        {
            try
            {
                this.context.Categories.Add(entity);
                this.context.SaveChanges();

            }
            catch ( Exception ex)
            {

                this.looger.LogError($"Error guardando la categoria. {ex.Message} ", ex.ToString());
            }
        }
    }
}
