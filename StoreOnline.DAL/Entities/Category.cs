using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StoreOnline.DAL.Entities
{
    [Table("Categories", Schema = "Production")]
    public class Category : Core.BaseEntity
    {
        [Column("categoryid")]    
        public int CategoryId { get; set; }
        
        [Column("categoryname")]
        public string? CategoryName { get; set; }
        
        [Column("description")]
        public string? CategoryDescription { get; set; }   

    }
}
