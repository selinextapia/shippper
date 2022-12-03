using System;

namespace StoreOnline.Service.Dtos.Suppliers
{
    public class SupplierRemoveDto
    {
        public int SupplierId { get; set; }
        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
