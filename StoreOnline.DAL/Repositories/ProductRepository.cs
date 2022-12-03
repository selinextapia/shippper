using StoreOnline.DAL.Context;
using StoreOnline.DAL.Entities;
using StoreOnline.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace StoreOnline.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreOnlineContext context;
        private readonly ILogger<StoreOnlineContext> logger;

        public ProductRepository(StoreOnlineContext context, ILogger<StoreOnlineContext> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(Expression<Func<Product, bool>> filter)
        {
            return this.context.Products.Any(filter);
        }

        public IEnumerable<Product> GetEntities()
        {
            return this.context.Products;
        }

        public IEnumerable<Product> GetEntities(Expression<Func<Product, bool>> filter)
        {
            return this.context.Products.Where(filter);
        }

        public Product GetEntity(int entityId)
        {
            return this.context.Products.Find(entityId);
        }

        public void Modify(Product entity)
        {
            try
            {
                this.context.Products.Update(entity);
                this.context.SaveChanges();
            }
            catch ( Exception ex)
            {

                this.logger.LogError($"Error modificando el producto. {ex.Message}", ex.ToString());
            }
        }

        public void Remove(Product entity)
        {
            try
            {
                this.context.Products.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex )
            {

                this.logger.LogError($"Error eliminando el producto. {ex.Message}", ex.ToString());
            }
        }

        public void Save(Product entity)
        {
            try
            {
                this.context.Products.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error guardando el producto. {ex.Message}", ex.ToString());
            }
        }
    }
}
