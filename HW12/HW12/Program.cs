using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace HW12.ObservableCollection;

static class Program
{
    static void Main(string[] args)
    { 
        // Создаем экземпляры классов, подписываемся на события через контсруктор
        Customer customer = new Customer();
        Shop shop = new Shop(customer.OnItemChanged);

        // Выводим меню
        Console.WriteLine("Для добавления товара нажмите 'A', для удаления товара - 'D', для выхода - 'X'");

        // Заводим флаг
        var flag = true;
        
        while (flag)
        {
            switch (Console.ReadKey().KeyChar)
            {
                case 'A':
                    Console.WriteLine();
                    // Добавляем товар в коллекцию
                    shop.Add();
                    break;
                case 'D':
                    Console.WriteLine();
                    // Удаляем товар из коллекции по id
                    RemoveItemById(shop);
                    break;
                case 'X':
                    // Выходим из программы
                    flag = false;
                    break;
            }
        }
    }

    // Уточняем id товара для удаленич
    private static void RemoveItemById(Shop shop)
    {
        Console.WriteLine("Введите id товара для удаления:");
        var flag = false;
        int id = -1;
        while (!flag)
        {
            if (Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine();
                if (shop.Remove(id))
                {
                    flag = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Товара с указанным id не существует, введите другой id");
                    continue;
                }
            }
            Console.WriteLine("Введите корректный id");
        }
    }


    // Реализуем класс Shop с 2-мя методами Add и Remove
    public class Shop
    {
        public readonly ObservableCollection<Item> Items = new ObservableCollection<Item>();

        public void Add()
        {
            Items.Add(new Item(Items.Count, "Товар от " + DateTime.Now));
        }

        public bool Remove(int id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                Items.Remove(item);
                return true;
            }
            return false;
        }

        public Shop(NotifyCollectionChangedEventHandler onItemChanged)
        {
            Items.CollectionChanged += onItemChanged;
        }
    }

    // Реализация класса Customer c реализацией подписки на измененения
    public class Customer
    {
        
        public void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
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

    // Реализация класса Item
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Item(int id, string? name)
        {
            Id = id;
            Name = name;
        }   
    }
}
