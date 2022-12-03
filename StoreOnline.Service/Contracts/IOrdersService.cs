using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Responses;

namespace StoreOnline.Service.Contracts
{
    public interface IOrdersService
    {
        OrdersResponse SaveOrders(OrdersSaveDto ordersSaveDto);
        OrdersResponse UpdateOrders(OrdersSaveDto ordersUpdateDto);
        ServiceResult RemoveOrders(OrdersSaveDto ordersRemoveDto);
        ServiceResult GetOrdersProduct();
        ServiceResult GetOrders();

    }

}
