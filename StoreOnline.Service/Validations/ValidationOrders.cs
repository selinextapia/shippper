using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Models;

namespace StoreOnline.Service.Validations
{
    public static class ValidationOrders
    {
        public static ServiceResult IsValidOrders(OrdersSaveDto ordersSaveDto)
        {
            ServiceResult result = new ServiceResult();

            //Validar campos requeridos y longitud//
            if (string.IsNullOrEmpty(ordersSaveDto.ShipName))
            {
                result.Success = false;
                result.Message = "Nombre de la orden es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(ordersSaveDto.ShipRegion))
            {
                result.Success = false;
                result.Message = "Direccion region de la orden es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(ordersSaveDto.ShipCity))
            {
                result.Success = false;
                result.Message = "Direccion ciudad de la orden es requerido";
                return result;
            }

            if (string.IsNullOrEmpty(ordersSaveDto.ShipPostalCode))
            {
                result.Success = false;
                result.Message = "Direccion postal de la orden es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(ordersSaveDto.ShipCountry))
            {
                result.Success = false;
                result.Message = "Direccion pais de la orden es requerido";
                return result;
            }


            if (ordersSaveDto.ShipName.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipAddress.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipCity.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipRegion.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipPostalCode.Length > 10)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipCountry.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;


            }
            return result;
        }

        public static ServiceResult IsValidOrder(OrdersUpdateDto ordersSaveDto)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(ordersSaveDto.ShipName))
            {
                result.Success = false;
                result.Message = "Nombre de la orden es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(ordersSaveDto.ShipRegion))
            {
                result.Success = false;
                result.Message = "Direccion region de la orden es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(ordersSaveDto.ShipCity))
            {
                result.Success = false;
                result.Message = "Direccion ciudad de la orden es requerido";
                return result;
            }

            if (string.IsNullOrEmpty(ordersSaveDto.ShipPostalCode))
            {
                result.Success = false;
                result.Message = "Direccion postal de la orden es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(ordersSaveDto.ShipCountry))
            {
                result.Success = false;
                result.Message = "Direccion pais de la orden es requerido";
                return result;
            }


            if (ordersSaveDto.ShipName.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipAddress.Length > 40)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipCity.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipRegion.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipPostalCode.Length > 10)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;
            }
            if (ordersSaveDto.ShipCountry.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud no es inválida";
                return result;


            }
            return result;




            return result;
        }


    }
}
