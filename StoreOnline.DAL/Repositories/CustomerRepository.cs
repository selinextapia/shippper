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
    public class CustomerRepository : ICustomerRepository
    {

        private readonly StoreOnlineContext context;
        private readonly ILogger<StoreOnlineContext> logger;
        public CustomerRepository(StoreOnlineContext context, ILogger<StoreOnlineContext> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(Expression<Func<Customer, bool>> filter)
        {
            return this.context.Customers.Any(filter);
        }

        public IEnumerable<Customer> GetEntities()
        {
            return this.context.Customers;
        }

        public IEnumerable<Customer> GetEntities(Expression<Func<Customer, bool>> filter)
        {
            return this.context.Customers.Where(filter);
        }

        public Customer GetEntity(int entityId)
        {
            return this.context.Customers.Find(entityId);
        }

        public void Modify(Customer entity)
        {
            try
            {
                this.context.Customers.Update(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error modificando el cliente. {ex.Message}", ex.ToString());
            }
        }

        public void Remove(Customer entity)
        {
            try
            {
                this.context.Customers.Remove(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error eliminando el cliente. {ex.Message}", ex.ToString());
            }
        }

        public void Save(Customer entity)
        {
            try
            {
                this.context.Customers.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError($"Error guardando el cliente. {ex.Message}", ex.ToString());
            }
        }
    }
}
