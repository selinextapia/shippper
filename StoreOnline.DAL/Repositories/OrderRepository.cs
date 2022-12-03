using Microsoft.Extensions.Logging;
using StoreOnline.DAL.Context;
using StoreOnline.DAL.Entities;
using StoreOnline.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StoreOnline.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly StoreOnlineContext context;
        private readonly ILogger<StoreOnlineContext> logger;

        public OrderRepository(StoreOnlineContext context, ILogger<StoreOnlineContext> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(Expression<Func<Order, bool>> filter)
        {
            return this.context.Orders.Any(filter);
        }

        public IEnumerable<Order> GetEntities()
        {
            return this.context.Orders;
        }

        public IEnumerable<Order> GetEntities(Expression<Func<Order, bool>> filter)
        {
            return this.context.Orders.Where(filter);
        }

        public Order GetEntity(int entityId)
        {
            return this.context.Orders.Find(entityId);
        }

        public void Modify(Order entity)
        {
            try
            {
                this.context.Orders.Update(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error modificando la Orden. {ex.Message}", ex.ToString());
            }
        }

        public void Remove(Order entity)
        {
            try
            {
                this.context.Orders.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error eliminando la orden. {ex.Message}", ex.ToString());
            }
        }

        public void Save(Order entity)
        {
            try
            {
                this.context.Orders.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error guardando la orden. {ex.Message}", ex.ToString());
            }
        }
    }
}
