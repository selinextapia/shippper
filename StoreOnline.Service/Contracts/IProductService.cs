using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos.Products;
using StoreOnline.Service.Responses;

namespace StoreOnline.Service.Contracts
{
    public interface IProductService
    {
        ProductResponce SaveProduct(ProductSaveDto productSaveDto);
        ProductResponce UpdateProduct(productUpdateDto productUpdateDto);
        ServiceResult RemoveProduct(ProductRemoveDto productRemoveDto);
        ServiceResult GetProduct();
    }
}
