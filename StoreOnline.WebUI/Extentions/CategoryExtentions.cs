
using StoreOnline.Service.Models;
using StoreOnline.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
namespace StoreOnline.WebUI.Extentions
{
    public static class CategoryExtentions
    {
        public static List<Category> ConvertCategoryModelToModel(this List<Service.Models.CategoryModel> categoryModels)
        {
            var myCategories = categoryModels.Select(category => new Category()
            {
                CategoriesName = category.CategoriesName,
                CategoriesDescription = category.CategoriesDescription,
                CategoryId = category.CategoryId,
                creation_date = category.creation_date
            }).ToList();

            return myCategories;

        }

        public static List<Category> GetCategory(List<Service.Models.CategoryModel> categoryModels)
        {
            var myCategories = categoryModels.Select(category => new Category()
            {
                CategoriesName = category.CategoriesName,
                CategoriesDescription = category.CategoriesDescription,
                CategoryId = category.CategoryId,
                creation_date = category.creation_date
            }).ToList();

            return myCategories;
        }

        public static Models.Category ConvertFromCategoryModelToCategory(this CategoryModel categoryModels)
        {
            return new Models.Category()
            {
                CategoriesName = categoryModels.CategoriesName,
                CategoriesDescription = categoryModels.CategoriesDescription,
                creation_date = categoryModels.creation_date
            };
        }
    }
}
