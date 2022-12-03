using StoreOnline.DAL.Interface;
using Microsoft.Extensions.Logging;
using StoreOnline.Service.Contracts;
using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Validations;//Extencion para  el refactory de la s validaciones//
using StoreOnline.Service.Exceptions;
using StoreOnline.Service.Responses;
using System;
using System.Linq;
using StoreOnline.Service.Models;

using School.Service.Extentions;

namespace StoreOnline.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private ILogger<CategoryService> logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            this.categoryRepository = categoryRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()//Proveniente del refactory, del IBaseservice//
        {
            ServiceResult result = new ServiceResult();


            try
            {
                var categories = categoryRepository.GetEntities();

                result.Data = categories.Select(cg => new Models.CategoryModel()
                {
                    CategoriesName = cg.CategoryName,
                    CategoriesDescription = cg.CategoryDescription,
                    creation_date = cg.Creation_Date.Date,
                    creation_dateDisplay = cg.Creation_Date.ToString("dd/mm/yy"),
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorias";
                this.logger.LogError($"{result.Message} {ex.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Category category = categoryRepository.GetEntity(Id);

                CategoryModel model = new CategoryModel()
                {
                    CategoryId = category.CategoryId,
                    CategoriesName = category.CategoryName,
                    CategoriesDescription = category.CategoryDescription,
                    creation_date = category.Creation_Date.Date,
                    creation_dateDisplay = category.Creation_Date.ToString("dd/mm/yy"),

                };

                result.Data = model;
            }
            catch (Exception ex )
            {
                result.Success = false;
                result.Message = "Error obteniendo la categoria del Id.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult GetCategories()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var categories = categoryRepository.GetEntities();
                result.Data = categories.Select(cg => new Models.CategoryModel()
                {
                    CategoryId = cg.CategoryId,
                    CategoriesDescription = cg.CategoryDescription,
                    creation_date = cg.Creation_Date.Date,//verificar porque no me funciona el value
                    creation_dateDisplay =  cg.Creation_Date.ToString("dd/mm/yyyy"),


                });
            }
            catch (CategoryException cex)
            { 
            
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error Obteniendo las categorias";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetCategoriesProduct()
        {
            throw new System.NotImplementedException();
        }
        public ServiceResult RemoveCategory(CategoryRemoveDto categoryRemoveDto)
        {
           ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Category categoryToRemove = categoryRepository.GetEntity(categoryRemoveDto.CategoryId);

                categoryToRemove.CategoryId = categoryRemoveDto.CategoryId;
                categoryToRemove.Delete_User = categoryRemoveDto.delete_user;
                categoryToRemove.Delete_Date = DateTime.Now;
                categoryToRemove.Deleted = true;
                    
                categoryRepository.Remove(categoryToRemove);
                result.Message = "Categoria eliminada corretamente";


            }
            catch (Exception ex)
            {
                result.Success=false;
                result.Message = "Error al eliminar la categoria";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());
               
            }
            return result;
        }
        public CategoryResponse SaveCategory(CategorySaveDto categorySaveDto)
        {
            CategoryResponse result = new CategoryResponse();
            try
            {

                var resutlIsValid = ValidationCategory.IsValidCategory(categorySaveDto);
                if (resutlIsValid.Success)
                {
                    if (categorySaveDto.depositDate.HasValue)
                    {

                        //verificar si el la categoria existe
                        if (categoryRepository.Exists(cg => cg.CategoryName == categorySaveDto.CategoriesName
                                                        && cg.CategoryDescription == categorySaveDto.CategoriesDescription
                                                        && cg.Creation_Date.Date == categorySaveDto.depositDate.Value.Date))
                        {
                            result.Success = false;
                            result.Message = "Esta categoria ya se encuentra ingresada";
                            return result;
                        }

                        DAL.Entities.Category categoryToAdd = new DAL.Entities.Category()
                        {
                            CategoryName = categorySaveDto.CategoriesName,
                            CategoryDescription = categorySaveDto.CategoriesDescription,
                            Creation_Date = DateTime.Now,
                            Creation_User = categorySaveDto.UserId,
                        };
                        categoryRepository.Save(categoryToAdd);

                        // result.Id = categoryToAdd.CategoryId.ToString();
                        
                        result.Message = "Categoria agregada corretamente";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "La fecha de inscripción es requerida.";
                        return result;
                    }

                }
                else
                {
                    result.Success = resutlIsValid.Success;
                    result.Message = resutlIsValid.Message;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la categoria";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            return result;
        }
        public CategoryResponse UpdateCategory(CategoryUpdateDto categorySaveDto)
        {
            CategoryResponse result = new CategoryResponse();
            try 
            {
                var resultIsValid = ValidationCategory.IsValidCategory(categorySaveDto);

                if (resultIsValid.Success)
                {
                    if (categorySaveDto.depositDate.HasValue)
                    {
                        DAL.Entities.Category categoryUpdateDto = categorySaveDto.ConvertFromCartegoryUpdateDtoToCartegoryEntity();

                        categoryRepository.Modify(categoryUpdateDto);

                        result.Message = "Categoria actualizada correctamente";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "La fecha del ingreso es requerida.";
                        return result;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = resultIsValid.Message;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la categoria";
                this.logger.LogError($" {result.Message}{ex.Message}", ex.ToString());

            }
            return result;
        }
    }
}
