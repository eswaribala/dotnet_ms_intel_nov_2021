using GraphQL;
using GraphQL.Types;
using InventoryService.GraphqlQueries;
using InventoryService.Models;
using InventoryService.Queries;
using InventoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * mutation($stock:StockInput!,$catalog:CatalogInput!,$product:ProductInput!,$location:LocationInput!){
  insertStockProductLocation(stock:$stock,catalog:$catalog,product:$product,location:$location){
  qty
    
    
  }
}
{
  "stock": {
    "qty": 6780,
     "comments": "verified",
    "productId": 1,
    "regionalCode": 1
  },
  "catalog": {
    "catalogName": "Electronics"
  },
  "product":{
    "productId": 1,
    "productType":0,
    "catalogId": 1,
    "productDetail": {
      "productName": "Laptop",
      "description": "test",
      "dOP": "2021-03-01",
      "cost": 56000
    }
  } ,
  "location": {
    "locationAddress": "chennai",
    "mobileNo": 9952032862,
"regionalCode": 1    
  }
}
 */


namespace InventoryService.GraphqlMutations
{
    public class CatalogMutation : ObjectGraphType
    {
      

     
        private readonly ICatalogRepository CatalogRepository;
       
        public CatalogMutation(ICatalogRepository _CatalogRepository)
        {
            
            CatalogRepository = _CatalogRepository;
            Field<CatalogGQLQuery>("insertCatalog",
             arguments: new QueryArguments(
           
                 new QueryArgument<CatalogGQLInputType> { Name = "catalog" }),
               
             resolve: context =>
             {
                
                 var catalog = context.GetArgument<Catalog>("catalog");
                
                 return InsertStock( catalog);
             });

            //Field<CatalogGQLQuery>("insertCatalog",
            //   arguments: new QueryArguments(new QueryArgument<CatalogGQLInputType> { Name = "catalog" }),
            //   resolve: context =>
            //   {
            //       return CatalogRepository.AddCatalog(context.GetArgument<Catalog>("catalog"));
            //   });

            Field<StringGraphType>(
                "DeleteCatalog",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>>
                { Name = "CatalogId" }),
                resolve: context =>
                {
                    var catalogId = context.GetArgument<long>("CatalogId");
                    CatalogRepository.DeleteCatalog(catalogId);
                    return $"CatalogId {catalogId} is successfully deleted";
                }
            );
        }
        private Catalog InsertStock(Catalog Catalog)
        {
            if (Catalog== null)
                return null;
            else
            {
               return CatalogRepository.AddCatalog(Catalog);
            }
        }
    }
}