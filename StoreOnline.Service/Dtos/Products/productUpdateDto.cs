
using System;

namespace StoreOnline.Service.Dtos.Products
{
    public class productUpdateDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime Modify_Date { get; set; }
        public int Modify_User { get; set; }

    }
}
