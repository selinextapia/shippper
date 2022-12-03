using StoreOnline.DAL.Context;
using StoreOnline.DAL.Entities;
using StoreOnline.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;

namespace StoreOnline.DAL.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreOnlineContext context;
        private readonly ILogger<StoreOnlineContext> logger;

        public SupplierRepository(StoreOnlineContext context, ILogger<StoreOnlineContext> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(Expression<Func<Supplier, bool>> filter)
        {
            return this.context.Suppliers.Any(filter);
        }

        public IEnumerable<Supplier> GetEntities()
        {
            return this.context.Suppliers;
        }

        public IEnumerable<Supplier> GetEntities(Expression<Func<Supplier, bool>> filter)
        {
            return this.context.Suppliers.Where(filter);
        }

        public Supplier GetEntity(int entityId)
        {
            return this.context.Suppliers.Find(entityId);
        }

        public void Modify(Supplier entity)
        {
            try
            {
                this.context.Suppliers.Update(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error modificando el suplidor. {ex.Message}", ex.ToString());
            }
        }

        public void Remove(Supplier entity)
        {
            try
            {
                this.context.Suppliers.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error eliminando el suplidor. {ex.Message}", ex.ToString());
            }
        }

        public void Save(Supplier entity)
        {
            try
            {
                this.context.Suppliers.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error guardando el suplidor. {ex.Message}", ex.ToString());
            }
        }
    }
}
