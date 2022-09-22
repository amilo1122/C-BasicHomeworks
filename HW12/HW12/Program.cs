namespace HW12;

static class Program
{
    static void Main(string[] args)
    { 

    }

    public class Shop
    {
        private List<Item> _items = new List<Item>();

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Remove(Item item)
        {
            _items.Remove(item);
        }
    }

    public class Customer
    {

    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
