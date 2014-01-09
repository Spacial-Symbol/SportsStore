using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using  ProductSite.Domain.Abstract ;
using  ProdcutSite.Models;

namespace ProdcutSite.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;

        public  NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        //public  PartialViewResult Menu(string catagory = null)
        //{
        //    IEnumerable<string> catagories = repository.Products
        //        .Select(x => x.Catagory)
        //        .Distinct()
        //        .OrderBy(x => x);
        //    return PartialView(catagories);
        //}

        public ViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category; 
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Catagory)
                .Distinct()
                .OrderBy(x => x); 
            return View(categories);
        } 
    }
}

