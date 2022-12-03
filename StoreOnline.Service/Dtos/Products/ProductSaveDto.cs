
using System;

namespace StoreOnline.Service.Dtos.Products
{
    public class ProductSaveDto
    {
        public string ProductName { get; set; }
        public DateTime Creation_Date { get; set; }
        public int Creation_User { get; set; }

    }
}
