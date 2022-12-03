

using System;

namespace StoreOnline.Service.Dtos
{
    public class CategoryRemoveDto
    {
        public int CategoryId { get; set; }

        public int delete_user { get; set; }
        public DateTime delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
