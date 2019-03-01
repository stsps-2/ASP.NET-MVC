using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class RequestModel
    {
        [JsonProperty(PropertyName = "toDelete")]
        public List<ProductModel> ToDelete { get; set; } = new List<ProductModel> { };

        [JsonProperty(PropertyName = "toUpdate")]
        public List<ProductModel> ToUpdate { get; set; } = new List<ProductModel> { };
    }
}
