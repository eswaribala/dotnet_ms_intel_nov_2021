using GraphQL.Types;
using InventoryService.GraphqlQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlMutations
{
    public class ProductGQLInputType : InputObjectGraphType
    {
        public ProductGQLInputType()
        {
            Name = "ProductInput";
            Field<NonNullGraphType<ProductDetailGQLInputType>>("ProductDetail");
            Field<NonNullGraphType<IntGraphType>>("ProductType");
            Field<NonNullGraphType<LongGraphType>>("ProductId");
            Field<NonNullGraphType<LongGraphType>>("CatalogId");

        }
    }
}