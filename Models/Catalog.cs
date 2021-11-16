using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InventoryService.Models
{
    [Table("Catalog")]
    public class Catalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Catalog_Id")]
        public long CatalogId { set; get; }
        [Column("Catalog_Name")]
        [Required]
        [StringLength(50)]
        public string CatalogName {  set; get; }
        [JsonIgnore]
        
        public Collection<Product> Products { set; get; }

    }
}
