using System;

namespace StoreOnline.Service.Dtos.Suppliers
{
    public class SupplierUpdateDto
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public int PostalCode { get; set; }
        public int Address { get; set; }
        public int City { get; set; }
        public DateTime Modify_Date { get; set; }
        public int Modify_User { get; set; }
    }
}
