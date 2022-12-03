using System;


namespace StoreOnline.Service.Dtos
{
    public class OrdersSaveDto 
    {
        public int CustId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public float Freight { get; set; }
        public int ShipperId { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public string? ShipAddress { get; set; }

    }
}
