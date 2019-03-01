using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warehouse.Interfaces;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductEntitiesService ProductEntitiesService;

        public HomeController(IProductEntitiesService productEntitiesService = null)
        {
            ProductEntitiesService = productEntitiesService;
        }

        public ActionResult Index()
        {
            return View(ProductEntitiesService.GetProducts().ToList());
        }

        [HttpPost]
        public ActionResult UpdateEntities(RequestModel model)
        {
            ProductEntitiesService.UpdateEntities(model);
            return Content("OK");
        }

        public ActionResult ShoppingList()
        {
            return View(ProductEntitiesService.GetShoppingList().ToList());
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id });
        }
    }
}