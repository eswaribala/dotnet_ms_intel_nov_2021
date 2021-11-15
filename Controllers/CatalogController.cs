using InventoryService.Models;
using InventoryService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace InventoryService.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        [Route("Catalogs")]
        [HttpGet]
        public ActionResult Get()
        {
            var catalogs = this._catalogRepository.GetAllCatalogs();
            return new OkObjectResult(catalogs);
        }

        // GET: CatalogController/Details/5
        // GET: api/Catalog/5
        [HttpGet("{catalogid}", Name = "Get")]
        public IActionResult Get(long catalogId)
        {
            var catalog = this._catalogRepository.GetCatalogById(catalogId);
            return new OkObjectResult(catalog);
        }
        

        // POST: CatalogController/Create
        [HttpPost]
        
        public ActionResult Post([FromBody] Catalog Catalog)
        {
            using (var scope = new TransactionScope())
            {
                _catalogRepository.AddCatalog(Catalog);
                scope.Complete();
                return CreatedAtAction(nameof(Get),
                    new { id = Catalog.CatalogId }, Catalog);
            }
        }



        

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{catalogId}")]
        public IActionResult Delete(long catalogId)
        {
            _catalogRepository.DeleteCatalog(catalogId);
            return new OkResult();
        }
    }
}
