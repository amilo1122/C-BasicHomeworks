using System.Collections.Immutable;

namespace HW12.ImmutableCollection;

static class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляры классов
        var myPart1 = new Part1();
        var myPart2 = new Part2();
        var myPart3 = new Part3();
        var myPart4 = new Part4();
        var myPart5 = new Part5();
        var myPart6 = new Part6();
        var myPart7 = new Part7();
        var myPart8 = new Part8();
        var myPart9 = new Part9();

        // Инициализируем Immutable коллекцию
        List<string> immutableList = new List<string>();

        // Вызываем методы добавления частей
        var poem = myPart9.AddPart(
        myPart8.AddPart(
        myPart7.AddPart(
        myPart6.AddPart(
        myPart5.AddPart(
        myPart4.AddPart(
        myPart3.AddPart(
        myPart2.AddPart(
        myPart1.AddPart(immutableList.ToImmutableList())))))))));
        
        // Выводим заголовок
        Console.WriteLine("Дом, который построил Джек");
        Console.WriteLine("--------------------------");

        // Выводим стихотворение
        foreach (var part in poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part1");
        Console.WriteLine("---------------------------");

        // Выводим поле 1 класса, содержащую 1 часть стихотворения
        foreach (var part in myPart1.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part2");
        Console.WriteLine("---------------------------");

        // Выводим поле 2 класса, содержащую 2 часть стихотворения
        foreach (var part in myPart2.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part3");
        Console.WriteLine("---------------------------");

        // Выводим поле 3 класса, содержащую 3 часть стихотворения
        foreach (var part in myPart3.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part4");
        Console.WriteLine("---------------------------");

        // Выводим поле 4 класса, содержащую 4 часть стихотворения
        foreach (var part in myPart4.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part5");
        Console.WriteLine("---------------------------");

        // Выводим поле 5 класса, содержащую 5 часть стихотворения
        foreach (var part in myPart5.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part6");
        Console.WriteLine("---------------------------");

        // Выводим поле 6 класса, содержащую 6 часть стихотворения
        foreach (var part in myPart6.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part7");
        Console.WriteLine("---------------------------");

        // Выводим поле 7 класса, содержащую 7 часть стихотворения
        foreach (var part in myPart7.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part8");
        Console.WriteLine("---------------------------");

        // Выводим поле 8 класса, содержащую 8 часть стихотворения
        foreach (var part in myPart8.Poem)
        {
            Console.WriteLine(part);
        }

        // Разделитель
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part9");
        Console.WriteLine("---------------------------");

        // Выводим поле 9 класса, содержащую 9 часть стихотворения
        foreach (var part in myPart9.Poem)
        {
            Console.WriteLine(part);
        }
    }
}

// Класс, содержащий 1 часть стихотворения
public class Part1
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();
    
    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; }}

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("Вот дом,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 2 часть стихотворения
public class Part2
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("А это пшеница,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 3 часть стихотворения
public class Part3
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("А это веселая птица-синица,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 4 часть стихотворения
public class Part4
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("Вот кот,");
        _poem.Add("Который пугает и ловит синицу,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 5 часть стихотворения
public class Part5
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("Вот пес без хвоста,");
        _poem.Add("Который за шиворот треплет кота,");
        _poem.Add("Который пугает и ловит синицу,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 6 часть стихотворения
public class Part6
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("А это корова безрогая,");
        _poem.Add("Лягнувшая старого пса без хвоста,");
        _poem.Add("Который за шиворот треплет кота,");
        _poem.Add("Который пугает и ловит синицу,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 7 часть стихотворения
public class Part7
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("А это старушка, седая и строгая,");
        _poem.Add("Которая доит корову безрогую,");
        _poem.Add("Лягнувшая старого пса без хвоста,");
        _poem.Add("Который за шиворот треплет кота,");
        _poem.Add("Который пугает и ловит синицу,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 8 часть стихотворения
public class Part8
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("А это ленивый и толстый пастух,");
        _poem.Add("Который бранится с коровницей строгою,");
        _poem.Add("Которая доит корову безрогую,");
        _poem.Add("Лягнувшая старого пса без хвоста,");
        _poem.Add("Который за шиворот треплет кота,");
        _poem.Add("Который пугает и ловит синицу,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

// Класс, содержащий 9 часть стихотворения
public class Part9
{
    // Инициализируем коллекцию
    private List<string> _poem = new List<string>();

    // Инициализируем свойство с публичным геттером
    public List<string> Poem { get { return _poem; } }

    //  Реализуем метод добавления новой части
    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("Вот два петуха,");
        _poem.Add("Которые будят того пастуха,");
        _poem.Add("Который бранится с коровницей строгою,");
        _poem.Add("Которая доит корову безрогую,");
        _poem.Add("Лягнувшая старого пса без хвоста,");
        _poem.Add("Который за шиворот треплет кота,");
        _poem.Add("Который пугает и ловит синицу,");
        _poem.Add("Которая часто ворует пшеницу,");
        _poem.Add("Которая в темном чулане хранится");
        _poem.Add("В доме,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}