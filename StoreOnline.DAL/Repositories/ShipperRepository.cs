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
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreOnlineContext context;
        private readonly ILogger<StoreOnlineContext> logger;

        public ShipperRepository(StoreOnlineContext context, ILogger<StoreOnlineContext> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exists(Expression<Func<Shipper, bool>> filter)
        {
            return this.context.Shippers.Any(filter);
        }

        public IEnumerable<Shipper> GetEntities()
        {
            return this.context.Shippers;
        }

        public IEnumerable<Shipper> GetEntities(Expression<Func<Shipper, bool>> filter)
        {
            return this.context.Shippers.Where(filter);
        }

        public Shipper GetEntity(int entityId)
        {
            return this.context.Shippers.Find(entityId);
        }

        public void Modify(Shipper entity)
        {
            try
            {
                this.context.Shippers.Update(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error modificando la embarcación. {ex.Message}", ex.ToString());
            }
        }

        public void Remove(Shipper entity)
        {
            try
            {
                this.context.Shippers.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error eliminando la embarcación. {ex.Message}", ex.ToString());
            }
        }

        public void Save(Shipper entity)
        {
            try
            {
                this.context.Shippers.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error guardando la embarcación. {ex.Message}", ex.ToString());
            }
        }
    }
}
