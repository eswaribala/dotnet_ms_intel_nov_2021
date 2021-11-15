using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryService.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private InventoryServiceContext _dbContext;

        //dependency Injection
        public CatalogRepository(InventoryServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Catalog AddCatalog(Catalog Catalog)
        {
            _dbContext.Add(Catalog);
            Save();
            return Catalog;

        }

        public bool DeleteCatalog(long CatalogId)
        {
            bool status = false;
            var catalog = _dbContext.Catalogs.Find(CatalogId);
            _dbContext.Catalogs.Remove(catalog);
            Save();
            if (GetCatalogById(CatalogId) == null)
                status = true;
            return status;
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return this._dbContext.Catalogs
               .Include(c => c.Products)
              .ToList();
        }

        public Catalog GetCatalogById(long CatalogId)
        {
            var catalog = _dbContext.Catalogs
               .Include(c => c.Products)
             .FirstOrDefault(x => x.CatalogId == CatalogId);
            return catalog;
        }


        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
