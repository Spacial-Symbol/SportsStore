using System.Linq;
using System.Web.Mvc;
using ProdcutSite.Models;
using ProductSite.Domain.Abstract;

namespace ProdcutSite.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4; // We will change this later 
        private IProductsRepository repository;

        public ProductController(IProductsRepository repoParam)
        {
            repository = repoParam;
        }

        public ViewResult List(string catagory ,int page = 1)
        {
            ProductsListViewModel viewModel = new ProductsListViewModel
                {
                    Products = repository.Products
                    .Where(p => catagory == null || p.Catagory == catagory)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                        {
                            CurrentPages = page,
                            ItemPerPages = PageSize,
                            TotalItems = catagory == null ? 
                            repository.Products.Count() : 
                            repository.Products.Where(e => e.Catagory == catagory).Count()                       
                        },
                        CurrentCatagory =  catagory
                };
            return View(viewModel); 

        } 
        //
        // GET: /Product/
        //public ActionResult List()
        //{
        //    return View(repository.Products);
        //}

    }
}
