using System;

namespace StoreOnline.WebUI.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoriesName { get; set; }
        public string CategoriesDescription { get; set; }
        public DateTime creation_date { get; set; }
    }
}
