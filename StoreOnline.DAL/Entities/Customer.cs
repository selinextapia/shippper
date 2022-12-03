using System.ComponentModel.DataAnnotations.Schema;

namespace StoreOnline.DAL.Entities
{


    [Table("Sales", Schema =  "Customers")]
    public class Customer : Core.BaseEntity
    {
    }
}
