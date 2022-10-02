using System.Collections.Concurrent;

namespace HW12.ConcurrentDictionary;

static class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляры классов, подписываемся на события через контсруктор
        ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
        var flag = true;

        // Формируем дополнительнвй поток
        Thread extThread = new Thread(() =>
        {
            while (flag)
            {
                Thread.Sleep(1000);
                // Формируем метод обхода основной коллекции
                foreach (var item in dict)
                {
                    var currentValue = item.Value;
                    if (item.Value < 100)
                    {
                        dict.TryUpdate(item.Key, currentValue + 1, currentValue);
                    }
                    else
                    {
                        dict.TryRemove(item.Key, out int deletedValue);
                    }
                }
            }
        });
        extThread.Start();

        // Запускаем основное меню
        while (flag)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в программу Библиотекарь\r");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Основное меню:");
            Console.WriteLine("\t1 - добавить книгу");
            Console.WriteLine("\t2 - вывести список непрочитанного");
            Console.WriteLine("\t3 - выйти");
            Console.WriteLine("-------------------------------------");
            Console.Write("Выберите опцию меню: ");
            var menuOption = Console.ReadLine();
            switch (menuOption)
            {
                case "1":
                    addBook(dict);
                    break;
                case "2":
                    displayList(dict);
                    break;
                case "3":
                    flag = false;
                    break;
                default:
                    break;
            }
        }       
        Console.ReadKey();
    }

    // Реализуем метод добавления
    private static void addBook(ConcurrentDictionary<string, int> dict)
    {
        string userInput = "";
        while (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Введите название книги:");
            userInput = Console.ReadLine();
        }
        dict.TryAdd(userInput, 0);
    }

    // Реализуем метод вывода коллекции элементов
    private static void displayList(ConcurrentDictionary<string, int> dict)
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Вывожу список книг");
        foreach (var key in dict)
        {
            Console.WriteLine(key.Key + " - " + key.Value + "%");
        }
        Console.ReadKey();
    }
     
}
