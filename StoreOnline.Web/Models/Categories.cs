namespace StoreOnline.Web.Models
{
    public class Categories 
    {
        string nombre;
        string descripcion;
        int id;


        public string Nombre
        {
            get { return nombre; }
            set {nombre = value; }

        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Id {get { return id; } set { id = value; } }     
       
    }
}
