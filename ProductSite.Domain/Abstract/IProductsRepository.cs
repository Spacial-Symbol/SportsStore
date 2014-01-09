using System.Linq;
using ProductSite.Domain.Entities;
namespace ProductSite.Domain.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }
    }
}
