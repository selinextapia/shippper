using StoreOnline.DAL.Interface;
using Microsoft.Extensions.Logging;
using StoreOnline.Service.Contracts;
using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Models;
using StoreOnline.Service.Exceptions;
using StoreOnline.Service.Validations;
using StoreOnline.Service.Responses;
using System;
using System.Linq;
using System.Data.SqlTypes;

namespace StoreOnline.Service.Services
{
   public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository OrderRepository;
        private ILogger<OrdersService> logger;

        public OrdersService(IOrderRepository OrderRepository, ILogger<OrdersService> logger)
        {
            this.OrderRepository = OrderRepository;
            this.logger = logger;
        }

        public ServiceResult GetOrders(int orderid)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetOrdersProduct()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetOrder(int orderid)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Order or = OrderRepository.GetEntity(orderid);

                OrderModel model = new OrderModel()
                {

                    OrderDate = or.OrderDate.Date,
                    RequiredDate = or.OrderDate.Date,
                    ShippedDate = or.ShippedDate.Date,
                    Freight = float.Parse(or.Freight.ToString()),
                    ShipperId = or.ShipperId,
                    ShipCity = or.ShipCity,
                    ShipRegion = or.ShipRegion,
                    ShipPostalCode = or.ShipPostalCode,
                    ShipCountry = or.ShipCountry,
                    ShipAddress = or.ShipAddress


                };
                result.Data = model; 
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Obteniendo Ordenes";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());
            }

            return result;
        }
     
        public ServiceResult RemoveOrders(OrdersRemoveDto ordersRemoveDto)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Order OrderToRemove = OrderRepository.GetEntity(ordersRemoveDto.orderid);

                OrderToRemove.OrderId = ordersRemoveDto.orderid;
                OrderToRemove.Delete_User = ordersRemoveDto.Delete_User;
                OrderToRemove.Deleted = true;
                OrderToRemove.Delete_Date = DateTime.Now;
            

                OrderRepository.Remove(OrderToRemove);
                result.Message = "Orden eliminada corretamente";


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar la orden";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            return result;
        }


        public OrdersResponse SaveOrders(OrdersSaveDto ordersSaveDto)
        {
            OrdersResponse result = new OrdersResponse();
            try
            {
                var resutlIsValid = ValidationOrders.IsValidOrders(ordersSaveDto);

             
                if (OrderRepository.Exists(or => or.ShipName== ordersSaveDto.ShipName
                                                 && or.CustId == ordersSaveDto.CustId
                                                 && or.ShipperId == ordersSaveDto.ShipperId))
                {
                    result.Success = false;
                    result.Message = "Orden registrada";
                    return result;
                }

                DAL.Entities.Order orderToAdd = new DAL.Entities.Order()
                {
                    ShipName = ordersSaveDto.ShipName,
                    ShipAddress = ordersSaveDto.ShipAddress,
                    ShipCity = ordersSaveDto.ShipCity,
                    ShipRegion = ordersSaveDto.ShipRegion,
                    ShipPostalCode = ordersSaveDto.ShipPostalCode,
                    ShipCountry = ordersSaveDto.ShipCountry

                };
                OrderRepository.Save(orderToAdd);
           
                result.Message = "Orden agregada corretamente";



            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la orden";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            return result;
        }
        public OrdersResponse UpdateOrders( OrdersUpdateDto ordersSaveDto)
        {
            OrdersResponse result = new OrdersResponse();
            try
            {
                var resutlIsValid = ValidationOrders.IsValidOrder(ordersSaveDto);


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la orden";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            DAL.Entities.Order orderToUpdate = OrderRepository.GetEntity(ordersSaveDto.OrderId);

            orderToUpdate.ShipName = ordersSaveDto.ShipName;
            orderToUpdate.RequiredDate = ordersSaveDto.OrderDate.Date;
            orderToUpdate.ShippedDate = ordersSaveDto.RequiredDate.Date;
            orderToUpdate.Freight = ordersSaveDto.Freight;
            orderToUpdate.ShipperId = ordersSaveDto.ShipperId;
            orderToUpdate.ShipCity = ordersSaveDto.ShipCity;
            orderToUpdate.ShipRegion = ordersSaveDto.ShipRegion;
            orderToUpdate.ShipPostalCode = ordersSaveDto.ShipPostalCode;
            orderToUpdate.ShipCountry = ordersSaveDto.ShipCountry;
            orderToUpdate.ShipAddress = ordersSaveDto.ShipAddress;

            OrderRepository.Modify(orderToUpdate);
            result.Message = "Orden modificada corretamente";


            return result;
        }

        public OrdersResponse UpdateOrders(OrdersSaveDto ordersUpdateDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult RemoveOrders(OrdersSaveDto ordersRemoveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}




