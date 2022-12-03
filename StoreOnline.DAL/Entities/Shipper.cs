using System.ComponentModel.DataAnnotations.Schema;

namespace StoreOnline.DAL.Entities
{
    [Table("Sales", Schema = "Shippers")]

    public class Shipper : Core.BaseEntity
    {
    }
}
