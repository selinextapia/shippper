

using System;

namespace StoreOnline.Service.Dtos.Products
{
    public class ProductRemoveDto
    {
        public int ProductId { get; set; }
        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
