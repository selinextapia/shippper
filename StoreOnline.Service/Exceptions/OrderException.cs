using System;

namespace StoreOnline.Service.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(String Message) : base(Message)
        {
            //Logica de negocios//
        }
    }
}
