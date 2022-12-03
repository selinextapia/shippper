using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Dtos.Suppliers;
using StoreOnline.Service.Responses;

namespace StoreOnline.Service.Contracts
{
    public interface ISupplierService
    {
        SupplierResponse SaveSupplier(SupplierSaveDto supplierSaveDto);
        SupplierResponse UpdateSupplier(SupplierUpdateDto supplierUpdateDto);
        ServiceResult RemoveSupplier(SupplierRemoveDto supplierRemoveDto);
        ServiceResult GetSuppliers();
    }
}
