using System;

namespace StoreOnline.Service.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string Message): base(Message)
        {
                //Logica de negocios//
        }
    }
}
