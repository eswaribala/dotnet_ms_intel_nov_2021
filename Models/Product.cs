using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    public enum ProductType { Regular,Seasonal}
    [Table("Product")]
    public class Product
    {
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Key]
      [Column("Product_Id")]
        public long ProductId { set; get; }

        public ProductDetail ProductDetail { set; get; }
        [Column("Product_Type")]
        public ProductType ProductType { set; get; }

        [ForeignKey("CatalogId")]
        [Column("Catalog_Id_FK")]
        public long CatalogId { set; get; }
        public Catalog Catalog { set; get; }

    }
}
