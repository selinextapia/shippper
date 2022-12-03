
using StoreOnline.Service.Core;
using StoreOnline.Service.Dtos;
using StoreOnline.Service.Responses;

namespace StoreOnline.Service.Contracts
{
    public interface ICategoryService : IBaseService
    {
        CategoryResponse SaveCategory(CategorySaveDto categorySaveDto);
        CategoryResponse UpdateCategory(CategoryUpdateDto categoryUpdateDto);
        ServiceResult RemoveCategory(CategoryRemoveDto categoryRemoveDto);
        ServiceResult GetCategoriesProduct();
        ServiceResult GetCategories();
    }
}
