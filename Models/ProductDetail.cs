using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Owned]
    public class ProductDetail
    {
        [Column("Product_Name")]
        [Required]
        public string ProductName { set; get; }

        [Column("Product_Description")]
        public string ProductDescription {  set; get; }

        [Column("DOP")]
        [Required]
        public DateTime DOP { set; get; }

        [Column("Cost")]
        [Required]
        public long Cost { set; get; }
    }
}
