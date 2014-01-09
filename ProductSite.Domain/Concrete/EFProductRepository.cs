using System.Linq;
using ProductSite.Domain.Entities;
using ProductSite.Domain.Abstract;
namespace ProductSite.Domain.Concrete
{
    public class EFProductRepository :IProductsRepository
    {
        private  EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
