using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlMutations
{
    public class CatalogGQLInputType:InputObjectGraphType
    {
        public CatalogGQLInputType(){
        Name = "CatalogInput";
        Field<NonNullGraphType<StringGraphType>>("CatalogName");
        
    }
}
}
