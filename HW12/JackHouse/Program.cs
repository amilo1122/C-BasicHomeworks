using System.Collections.Immutable;

namespace HW12.ImmutableCollection;

static class Program
{
    static void Main(string[] args)
    {
        var myPart1 = new Part1();
        var myPart2 = new Part2();
        var myPart3 = new Part3();
        var myPart4 = new Part4();
        var myPart5 = new Part5();
        var myPart6 = new Part6();
        var myPart7 = new Part7();
        var myPart8 = new Part8();
        var myPart9 = new Part9();

        List<string> immutableList = new List<string>();
        //ImmutableList<string> immutableList = new ImmutableList<string>();

        var poem = myPart9.AddPart(
        myPart8.AddPart(
        myPart7.AddPart(
        myPart6.AddPart(
        myPart5.AddPart(
        myPart4.AddPart(
        myPart3.AddPart(
        myPart2.AddPart(
        myPart1.AddPart(immutableList.ToImmutableList())))))))));
        Console.WriteLine("Дом, который построил Джек");
        Console.WriteLine("--------------------------");
        foreach (var part in poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part1");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart1.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part2");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart2.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part3");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart3.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part4");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart4.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part5");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart5.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part6");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart6.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part7");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart7.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part8");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart8.Poem)
        {
            Console.WriteLine(part);
        }
        Console.WriteLine("---------------------------");
        Console.WriteLine("Part9");
        Console.WriteLine("---------------------------");
        foreach (var part in myPart9.Poem)
        {
            Console.WriteLine(part);
        }
    }
}
public class Part1
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; }}

    public ImmutableList<string> AddPart(ImmutableList<string> list)
    {
        _poem = list.ToList();
        _poem.Add("Вот дом,");
        _poem.Add("Который построил Джек.");
        return _poem.ToImmutableList();
    }
}

public class Part2
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part3
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part4
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part5
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part6
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part7
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part8
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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

public class Part9
{
    private List<string> _poem = new List<string>();
    public List<string> Poem { get { return _poem; } }

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