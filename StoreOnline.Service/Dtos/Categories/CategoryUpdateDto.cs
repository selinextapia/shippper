

using StoreOnline.Service.Core;
using System;

namespace StoreOnline.Service.Dtos
{
    public class CategoryUpdateDto : DtoCategoryBase
    {
        public int CategoryId { get; set; }
        public string? CategoriesName { get; set; }
        public string? CategoriesDescription { get; set; }
        public DateTime modify_date { get; set; }
        public int modify_user { get; set; }

    }
}
