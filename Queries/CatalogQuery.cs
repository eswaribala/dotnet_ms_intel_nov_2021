using GraphQL;
using GraphQL.Types;
using InventoryService.Repositories;

namespace InventoryService.Queries
{
    public class CatalogQuery:ObjectGraphType
    {
        public CatalogQuery(ICatalogRepository CatalogRepository)
        {
            Name = "CatalogQuery";
            //get all catalogs
            Field<ListGraphType<CatalogGQLQuery>>(
              "catalogs",
              resolve: context => CatalogRepository.GetAllCatalogs()
          );

            //get catalog by id
            Field<CatalogGQLQuery>(
               "catalog",
               arguments: new QueryArguments(new QueryArgument<LongGraphType> { Name = "catalogId" }),
               resolve: context => CatalogRepository.GetCatalogById(context.GetArgument<long>("catalogId"))

               );

        }
    }
}
