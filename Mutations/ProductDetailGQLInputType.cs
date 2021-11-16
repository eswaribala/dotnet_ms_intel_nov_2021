using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class ProductDetailGQLInputType : InputObjectGraphType
    {
        public ProductDetailGQLInputType()
        {
            Name = "ProductDetailInput";
            Field<NonNullGraphType<StringGraphType>>("ProductName");
            Field<NonNullGraphType<StringGraphType>>("Description");
            Field<NonNullGraphType<DateGraphType>>("DOP");
            Field<NonNullGraphType<LongGraphType>>("Cost");


        }
    }
}
