using System;

namespace StoreOnline.Service.Dtos.Suppliers
{
    public class SupplierSaveDto
    {
         public string CompanyName { get; set; }
        public int PostalCode { get; set; }
        public int Address { get; set; }
        public int City { get; set; }
        public DateTime Creation_Date { get; set; }
        public int Creation_User { get; set; }
    }
}
