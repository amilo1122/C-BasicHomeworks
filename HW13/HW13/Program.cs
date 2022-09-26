namespace HW13;

static class Program
{
    static void Main(string[] args)
    {
        // Инициализируем первую коллекцию
        var intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Инициализируем вторую коллекцию
        var objList = new List<Person> { 
            new Person(1, 15),
            new Person(2, 45),
            new Person(3, 35),
            new Person(4, 59),
            new Person(5, 10),
            new Person(6, 17),
            new Person(7, 55),
            new Person(8, 67),
            new Person(9, 3)  
        };

        // Вызываем мепрую перегрузку
        var newIntList = intList.Top(30);
        Console.WriteLine(string.Join(" ", newIntList));

        // Вызываем вторую перегрузку
        var newObjList = objList.Top(30, person => person.Age);
        Console.WriteLine(string.Join(" ", newObjList));

    }
    
    // Первая перешрузка
    public static IEnumerable<int> Top(this IEnumerable<int> items, double X)
    {
        if (X > 100 || X < 0)
        {
            throw new ArgumentException();
        }

        var count = X / 100 * items.Count();
        var countToReturn = Math.Ceiling(count);

        return items.Reverse().Take((int)countToReturn);
    }

    // Вторая перегрузка
    public static IEnumerable<Person> Top(this IEnumerable<Person> items, double X, AgeExtractor func)
    {
        var sortedList = items.OrderByDescending(s => func(s));

        if (X > 100 || X < 0)
        {
            throw new ArgumentException();
        }

        var count = X / 100 * items.Count();
        var countToReturn = Math.Ceiling(count);

        return sortedList.Take((int)countToReturn);
    }

    // Описываем делегат
    public delegate int AgeExtractor(Person person);

    // Описываем класс Person
    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public Person(int id, int age)
        {
            Id = id;
            Age = age;
        }

        // Переопределяем метод ToString() для корректного вывода списока объектов
        public override string ToString()
        {
            return "Id" + Id + "-Age" + Age + ";";
        }
    }
}
