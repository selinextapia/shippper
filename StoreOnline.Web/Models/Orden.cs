namespace StoreOnline.Web.Models
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string CiudadCliente { get; set; }

    }
}
