
using System;

namespace StoreOnline.Service.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoriesName { get; set; }
        public string CategoriesDescription { get; set; }  
        public DateTime creation_date { get; set; }
        public string creation_dateDisplay { get; set; }

    }
}       
