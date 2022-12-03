using System;

namespace StoreOnline.Service.Models.Suppliers
{
    public class SupplierModel
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        public int PostalCode { get; set; }
        public int Address { get; set; }
        public int City { get; set; }
        public DateTime Creation_Date { get; set; }
    }
}
