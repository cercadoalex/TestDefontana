namespace Arbol.Entities
{

    public class Organismo
    {
        public List<Item> data { get; set; }
    }

    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }

    }

}
