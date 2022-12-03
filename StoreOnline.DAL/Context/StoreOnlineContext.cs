using Microsoft.EntityFrameworkCore;
using StoreOnline.DAL.Entities;


namespace StoreOnline.DAL.Context
{
    public class StoreOnlineContext : DbContext
    {
        public StoreOnlineContext()
        {

        }

       public StoreOnlineContext(DbContextOptions<StoreOnlineContext> options)
            : base(options)
        {

        }
        #region
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #endregion
    }


}
