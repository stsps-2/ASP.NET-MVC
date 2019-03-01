using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Warehouse.Models;
using Warehouse.Interfaces;
using Warehouse.Data.Models;

namespace Warehouse.Services
{
    public class ProductEntitiesService : IProductEntitiesService
    {
        private readonly WarehouseContext Context = new WarehouseContext();

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return Context.Products.Select(ConvertToProductViewModel);
        }

        public IEnumerable<ProductViewModel> GetShoppingList()
        {
            return Context.Products.Where(i => i.Quantity == 0).Select(ConvertToProductViewModel);
        }

        public void UpdateEntities(RequestModel model)
        {
            foreach (var entity in model.ToDelete)
            {
                var product = Context.Products.Where(i => i.Name == entity.Name.Replace("'", "").Replace("\"", "").Trim()).FirstOrDefault();
                if (product != null)
                    Context.Products.Remove(product);
            }

            foreach (var entity in model.ToUpdate)
            {
                var product = Context.Products.Where(i => i.Name == entity.Name.Replace("'", "").Replace("\"", "").Trim()).FirstOrDefault();
                if (product != null)
                    product.Quantity += entity.Quantity;
                else
                    Context.Products.Add(new Product()
                    {
                        Name = entity.Name.Replace("'", "").Replace("\"", "").Trim(),
                        Quantity = entity.Quantity,
                        DefaultValue = entity.Quantity
                    });
            }

            Context.SaveChanges();
        }

        #region Helpers
        private static ProductViewModel ConvertToProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Name = product.Name,
                Quantity = product.Quantity,
                DefaultValue = product.DefaultValue ?? 1
            };
        }
        #endregion
    }
}