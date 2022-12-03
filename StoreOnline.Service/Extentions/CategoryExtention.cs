
using StoreOnline.Service.Dtos;
using StoreOnline.DAL.Entities;

namespace School.Service.Extentions
{
    public static class CartegoryExtention
    {
        public static Category ConvertFromCartegoryUpdateDtoToCartegoryEntity(this CategoryUpdateDto categoryUpdateDto)
        {
            return new Category()
            {
                CategoryId = categoryUpdateDto.CategoryId,
                CategoryName = categoryUpdateDto.CategoriesName,
                CategoryDescription = categoryUpdateDto.CategoriesDescription,
                Modify_Date = categoryUpdateDto.modify_date,
                Modify_User = categoryUpdateDto.UserId
            };
        }
    }
}
