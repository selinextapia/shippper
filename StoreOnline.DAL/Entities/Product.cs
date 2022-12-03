using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace StoreOnline.DAL.Entities
{
    [Table("Products", Schema = "Production")]
    public class Product : Core.BaseEntity
    {
        [Column("productid")]
        public int ProductId { get; set; }

        [Column("productname")]
        public string? ProductName { get; set; }

        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        [Column("discontinued")]
        public bool Discontinued { get; set; }
        
    }
}
