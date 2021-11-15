using InventoryService.Models;
using System.Collections.Generic;

namespace InventoryService.Repositories
{
    public interface IProductRepository
    {

        Product AddProduct(Product Product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(long ProductId);
        bool DeleteProduct(long ProductId);
    }
}
