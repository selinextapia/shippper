using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Models;

namespace StoreOnline.Service.Validations
{
    public static class ValidationCategory
    {
        public static ServiceResult IsValidCategory(CategorySaveDto category)
        {
            ServiceResult result = new ServiceResult();

            //Validar campos requeridos y longitud//
            if (string.IsNullOrEmpty(category.CategoriesName))
            {
                result.Success = false;
                result.Message = "El nombre de la categoria es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(category.CategoriesDescription))
            {
                result.Success = false;
                result.Message = "La descripcion de la categoria es requerido";
                return result;
            }


            if (category.CategoriesName.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud de la categoria es inválida";
                return result;
            }
            if (category.CategoriesDescription.Length > 200)
            {
                result.Success = false;
                result.Message = "La longitud de la categoria es inválida";
                return result;
            }


            return result;
        }
        public static ServiceResult IsValidCategory(CategoryUpdateDto category)
        {
            ServiceResult result = new ServiceResult();

            //Validar campos requeridos y longitud//
            if (string.IsNullOrEmpty(category.CategoriesName))
            {
                result.Success = false;
                result.Message = "El nombre de la categoria es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(category.CategoriesDescription))
            {
                result.Success = false;
                result.Message = "La descripcion de la categoria es requerido";
                return result;
            }


            if (category.CategoriesName.Length > 15)
            {
                result.Success = false;
                result.Message = "La longitud de la categoria es inválida";
                return result;
            }
            if (category.CategoriesDescription.Length > 200)
            {
                result.Success = false;
                result.Message = "La longitud de la categoria es inválida";
                return result;
            }


            return result;
        }


    }
}
