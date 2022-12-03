
using Microsoft.Extensions.Logging;
using StoreOnline.DAL.Interface;
using StoreOnline.Service.Contracts;
using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos.Products;
using StoreOnline.Service.Exceptions;
using StoreOnline.Service.Responses;
using System;
using System.Linq;

namespace StoreOnline.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private ILogger<ProductService> logger;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            this.productRepository = productRepository;
            logger = logger;
        }

        public ServiceResult GetProduct()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var products = productRepository.GetEntities();
                result.Data = products.Select(pd => new Models.Product.ProductModel()
                {
                    ProductId = pd.ProductId,
                    ProductName = pd.ProductName,
                    Creation_Date = pd.Creation_Date.Date,
                });
            }
            catch (ProductException pex)
            {

            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = "Error Obteniendo las categorias";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult RemoveProduct(ProductRemoveDto productRemoveDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Product productToRemove = productRepository.GetEntity(productRemoveDto.ProductId);

                productToRemove.ProductId = productRemoveDto.ProductId;
                productToRemove.Delete_User = productRemoveDto.delete_user;
                productToRemove.Delete_Date = DateTime.Now;
                productToRemove.Deleted = true;

                productRepository.Remove(productToRemove);
                result.Message = "Producto eliminada corretamente";
            }catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el producto";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());
            }

            return result;
        }

        public ProductResponce SaveProduct(ProductSaveDto productSaveDto)
        {
            ProductResponce result = new ProductResponce();

            try
            {//Validacionde los campos requeridos//
                if (string.IsNullOrEmpty(productSaveDto.ProductName))
                {
                    result.Success = false;
                    result.Message = "El nombre del producto es requerido";
                    return result;
                }
                //Validacion de la longitud de los datos //

                if (productSaveDto.ProductName.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del producto es inválida";
                    return result;
                }
                //verificar si el producto existe
                if(productRepository.Exists(pd => pd.ProductName == productSaveDto.ProductName
                                                && pd.Creation_Date.Date == productSaveDto.Creation_Date.Date))
                {
                    result.Success = false;
                    result.Message = "Este producto ya se encuentra ingresada";
                    return result;
                }

                DAL.Entities.Product productToAdd = new DAL.Entities.Product()
                {
                    ProductName = productSaveDto.ProductName,
                    Creation_Date = DateTime.Now,
                    Creation_User = productSaveDto.Creation_User,
                };
                productRepository.Save(productToAdd);
                result.Message = "Producto agregado correctamente";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el producto";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }

            return result;
        }

        public ProductResponce UpdateProduct(productUpdateDto productSaveDto)
        {
            ProductResponce result = new ProductResponce();

            try
            {
                if (string.IsNullOrEmpty(productSaveDto.ProductName))
                {
                    result.Success = false;
                    result.Message = "El nombre del producto es requerido";
                    return result;
                }
                //Validacion de la longitud de los datos //

                if (productSaveDto.ProductName.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud del producto es inválida";
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el producto";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());
            }
            DAL.Entities.Product productToUpdate = productRepository.GetEntity(productSaveDto.ProductId);
            
            productSaveDto.ProductId = productSaveDto.ProductId;
            productToUpdate.ProductName=productSaveDto.ProductName;
            productToUpdate.Modify_Date = DateTime.Now;
            productToUpdate.Modify_User = productSaveDto.Modify_User;
            
            productRepository.Modify(productToUpdate);
            result.Message = "Producto modificado correctamente";

            return result;
        }
    }
}
