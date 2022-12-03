using System;
using StoreOnline.DAL.Entities;

namespace StoreOnline.Service.Dtos
{
    public class OrdersRemoveDto : Order 
    {
        public int orderid { get; set; }
    }
}

