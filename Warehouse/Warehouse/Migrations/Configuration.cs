using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Warehouse.Data.Models;

namespace Warehouse.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WarehouseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WarehouseContext context)
        {
            var products = new List<Product>
            {
                new Product { Name = "Milk", Quantity = 2,
                    DefaultValue = 3 },
                new Product { Name = "Butter", Quantity = 1,
                    DefaultValue = 2 },
                new Product { Name = "Bread", Quantity = 1,
                    DefaultValue = 1 },
                new Product { Name = "Water", Quantity = 3,
                    DefaultValue = 2 },
            };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
