using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace StoreOnline.DAL.Entities
{
    [Table("Orders", Schema = "Sales")]
    public class Order : Core.BaseEntity
    {
        [Column("orderid")]
        public int OrderId { get; set; }

        [Column("custid")]
        public int CustId { get; set; }

        [Column("orderdate")]
        public DateTime OrderDate { get; set; }

        [Column("requireddate")]
        public DateTime RequiredDate { get; set; }

        [Column("shippeddate")]
        public DateTime ShippedDate { get; set; }

        [Column("freight")]
        public float Freight { get; set; }

        [Column("shipperid")]
        public int ShipperId { get; set; }

        [Column("shipname")]
        public string? ShipName { get; set; }

        [Column("shipcity")]
        public string? ShipCity { get; set; }

        [Column("shipregion")]
        public string? ShipRegion { get; set; }

        [Column("shippostalcode")]
        public string? ShipPostalCode { get; set; }

        [Column("shipcountry")]
        public string? ShipCountry { get; set; }

        [Column("shipaddress")]
        public string? ShipAddress { get; set; }

    }
}
