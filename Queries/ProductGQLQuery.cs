using GraphQL.Types;
using InventoryService.Models;

namespace InventoryService.Queries
{
    public class ProductGQLQuery:ObjectGraphType<Product>
    {
        public ProductGQLQuery()
        {
            Name = "Product";
            Field(_ => _.ProductId).Description("Product Id");
            Field(_ => _.ProductDetail.ProductName).Description("Product Name");
            Field(_ => _.ProductDetail.ProductDescription).Description("Product Description");
            Field(_ => _.ProductDetail.Cost).Description("Cost");
            Field(_ => _.ProductDetail.DOP).Description("DOP");
            Field(_ => _.ProductType).Description("Product Type");
        }
    }
}
