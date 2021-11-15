using InventoryService.Contexts;
using InventoryService.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryService.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private InventoryServiceContext _dbContext; 

        public ProductRepository(InventoryServiceContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Product AddProduct(Product Product)
        {
            _dbContext.Add(Product);
            Save();
            return Product; 
        }

        public bool DeleteProduct(long ProductId)
        {
            bool status = false;
            var product = _dbContext.Products.Find(ProductId);
            _dbContext.Products.Remove(product);
            Save();
            if (GetProductById(ProductId) == null)
                status = true;
            return status;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this._dbContext.Products
               //.Include(p =>p.ProductSuppliers )
               .ToList();
        }

        public Product GetProductById(long ProductId)
        {
            var product = _dbContext.Products
              //.Include(p => p.ProductSuppliers)
              .FirstOrDefault(x => x.ProductId == ProductId);
            return product;
        }

        private void Save()
        {
            this._dbContext.SaveChanges();
        }
    }
}
