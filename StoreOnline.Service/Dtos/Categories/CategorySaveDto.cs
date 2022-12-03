
using StoreOnline.Service.Core;
using System;

namespace StoreOnline.Service.Dtos
{
    public class CategorySaveDto : DtoCategoryBase
    {
        public string? CategoriesName { get; set; }
        public string? CategoriesDescription { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }

    }
}
