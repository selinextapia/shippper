using System;

namespace StoreOnline.Service.Exceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(String Message): base(Message)
        {
                //Logica de negocios//
        }
    }
}
