using InventoryService.Models;
using System.Collections.Generic;

namespace InventoryService.Repositories
{
    public interface ICatalogRepository
    {
        Catalog AddCatalog(Catalog Catalog);
        IEnumerable<Catalog> GetAllCatalogs();
        Catalog GetCatalogById(long CatalogId);
        bool DeleteCatalog(long CatalogId);


    }
}
