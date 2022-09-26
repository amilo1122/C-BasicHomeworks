using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace HW12;

static class Program
{
    static void Main(string[] args)
    { 

    }

    public class Shop
    {
        public readonly ObservableCollection<Item> Items = new ObservableCollection<Item>();

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

    }

    public class Customer
    {
        
        void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems?[0] is Item newItem)
                        Console.WriteLine($"Добавлен новый товар: {newItem.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    if (e.OldItems?[0] is Item oldItem)
                        Console.WriteLine($"Удален товар: {oldItem.Name}");
                    break;
            }
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
