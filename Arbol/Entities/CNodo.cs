namespace Arbol.Entities
{
    public class CNodo
    {

        public string dato { get; set; }
        public int valor { get; set; }

        public CNodo hijo { get; set; }

        public CNodo hermano { get; set; }

        public CNodo()
        {
            dato = "";
            hijo = null;
            hermano = null;
        }

    }
}
