using StoreOnline.Service.Contracts;
using Microsoft.Extensions.Logging;
using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos.Suppliers;
using StoreOnline.Service.Exceptions;
using StoreOnline.Service.Responses;
using System;
using System.Linq;
using StoreOnline.DAL.Interface;
using StoreOnline.DAL.Repositories;
using StoreOnline.Service.Dtos;

namespace StoreOnline.Service.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private ILogger<SupplierService> logger;

        public SupplierService(ISupplierRepository supplierRepository, ILogger<SupplierService> logger)
        { 
            this.supplierRepository = supplierRepository;
            this.logger = logger;
        
        }
        public ServiceResult GetSuppliers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var suppliers = supplierRepository.GetEntities();
                result.Data = suppliers.Select(sp => new Models.Suppliers.SupplierModel()
                {
                    SupplierId = sp.SupplierId,
                    CompanyName = sp.CompanyName,
                    PostalCode = int.Parse(sp.PostalCode),
                    Address = int.Parse(sp.Address),
                    City = int.Parse(sp.City),
                    Creation_Date = sp.Creation_Date.Date,
                });
            }
            catch (SupplierException sex)
            {

            }
            catch(Exception ex) 
            { 
                result.Success = false;
                result.Message = "Error obteniendo los suplidores";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }
            
            return result;
        }

        public ServiceResult RemoveSupplier(SupplierRemoveDto supplierRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Supplier suplierToRemove = supplierRepository.GetEntity(supplierRemoveDto.SupplierId);

                suplierToRemove.SupplierId = supplierRemoveDto.SupplierId;
                suplierToRemove.Delete_User = supplierRemoveDto.delete_user;
                suplierToRemove.Delete_Date = DateTime.Now;
                suplierToRemove.Deleted = true;

                supplierRepository.Remove(suplierToRemove);
                result.Message = "Suplidor eliminado correctamente";
            }
            catch(Exception ex)
            {
                result.Success=false;
                result.Message = "Error eliminando el suplidor";
                this.logger.LogError($" {result.Message} {ex.Message}", ex.ToString());
            }



            return result;
        }

        public SupplierResponse SaveSupplier(SupplierSaveDto supplierSaveDto)
        {

            SupplierResponse result = new SupplierResponse();
            try
            {       //Validacionde los campos requeridos//
                if (string.IsNullOrEmpty(supplierSaveDto.CompanyName))
                {
                    result.Success = false;
                    result.Message = "El nombre del suplidor es requerido";
                    return result;
                }
                if (string.IsNullOrEmpty(supplierSaveDto.PostalCode.ToString()))
                {
                    result.Success = false;
                    result.Message = "El codigo postal del suplidor es requerido";
                    return result;
                }
                if (string.IsNullOrEmpty(supplierSaveDto.Address.ToString()))
                {
                    result.Success = false;
                    result.Message = "La direccion del suplidor es requerida";
                    return result;
                }
                if (string.IsNullOrEmpty(supplierSaveDto.City.ToString()))
                {
                    result.Success = false;
                    result.Message = "La ciudad del suplidor es requerida";
                    return result;
                }
                //Validacion de la longitud de los datos //

                if (supplierSaveDto.CompanyName.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del nombre del suplidor es invalida";
                    return result;
                }
                if (supplierSaveDto.PostalCode.ToString().Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del codigo postal del suplidor es invalida";
                    return result;
                }
                if (supplierSaveDto.Address.ToString().Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud de la direccion del suplidor es invalida";
                    return result;
                }
                if (supplierSaveDto.City.ToString().Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud de la ciudad del suplidor es invalida";
                    return result;
                }
                //Verificar si el suplidor exixte//

                if(supplierRepository.Exists(sp => sp.CompanyName == supplierSaveDto.CompanyName
                                                && sp.PostalCode == supplierSaveDto.PostalCode.ToString()
                                                && sp.Address == supplierSaveDto.Address.ToString()
                                                && sp.City == supplierSaveDto.City.ToString()))
                {
                    result.Success = false;
                    result.Message = "Este suplidor ya se encuentra ingesado";
                    return result;
                }

                DAL.Entities.Supplier supplierToAdd = new DAL.Entities.Supplier()
                {
                    CompanyName = supplierSaveDto.CompanyName,
                    PostalCode = supplierSaveDto.PostalCode.ToString(),
                    Address = supplierSaveDto.Address.ToString(),
                    City = supplierSaveDto.City.ToString(),
                    Creation_Date = DateTime.Now,
                };
                supplierRepository.Save(supplierToAdd);
                result.Message = "Suplidor agregado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el suplidor";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            return result;
        }

        public SupplierResponse UpdateSupplier(SupplierUpdateDto supplierSaveDto)
        {
            SupplierResponse result = new SupplierResponse();
            try
            {

                if (string.IsNullOrEmpty(supplierSaveDto.CompanyName))
                {
                    result.Success = false;
                    result.Message = "El nombre del suplidor es requerido";
                    return result;
                }
                if (string.IsNullOrEmpty(supplierSaveDto.PostalCode.ToString()))
                {
                    result.Success = false;
                    result.Message = "El codigo postal del suplidor es requerido";
                    return result;
                }
                if (string.IsNullOrEmpty(supplierSaveDto.Address.ToString()))
                {
                    result.Success = false;
                    result.Message = "La direccion del suplidor es requerida";
                    return result;
                }
                if (string.IsNullOrEmpty(supplierSaveDto.City.ToString()))
                {
                    result.Success = false;
                    result.Message = "La ciudad del suplidor es requerida";
                    return result;
                }
                //Validacion de la longitud de los datos //

                if (supplierSaveDto.CompanyName.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del nombre del suplidor es invalida";
                    return result;
                }
                if (supplierSaveDto.PostalCode.ToString().Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del codigo postal del suplidor es invalida";
                    return result;
                }
                if (supplierSaveDto.Address.ToString().Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud de la direccion del suplidor es invalida";
                    return result;
                }
                if (supplierSaveDto.City.ToString().Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud de la ciudad del suplidor es invalida";
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el suplidor";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            DAL.Entities.Supplier supplierToUpdate = supplierRepository.GetEntity(supplierSaveDto.SupplierId);
           
                supplierToUpdate.CompanyName = supplierSaveDto.CompanyName;
                supplierSaveDto.Address = supplierSaveDto.Address;
                supplierSaveDto.City = supplierSaveDto.City;
                supplierSaveDto.PostalCode = supplierSaveDto.PostalCode;
                supplierSaveDto.Modify_Date = DateTime.Now;
                supplierSaveDto.Modify_User = supplierSaveDto.Modify_User;
                supplierSaveDto.SupplierId = supplierSaveDto.SupplierId;

            supplierRepository.Modify(supplierToUpdate);
            result.Message = "Suplidor modificado correctamente";

            return result;
            
        }
    }
}
