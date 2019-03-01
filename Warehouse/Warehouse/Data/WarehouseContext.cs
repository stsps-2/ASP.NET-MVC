using System.Data.Entity;
using Warehouse.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Warehouse.Data.Models
{
    public partial class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("DataConnection")
        {
        }

        public static WarehouseContext Create()
        {
            return new WarehouseContext();
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}