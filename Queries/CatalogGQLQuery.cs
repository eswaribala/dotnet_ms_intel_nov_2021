using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Queries
{
    public class CatalogGQLQuery:ObjectGraphType<Catalog>
    {

        public CatalogGQLQuery()
        {
            Name = "Catalog";
            Field(_ => _.CatalogId).Description("Catalog Id.");
            Field(_ => _.CatalogName).Description("Catalog Name.");
        }
    }
}
