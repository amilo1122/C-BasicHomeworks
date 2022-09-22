namespace HW13;

static class Program
{
    static void Main(string[] args)
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var newList = list.Top(30);
        Console.WriteLine(string.Join(" ", newList));

        var newList1 = list.Top(30, person => person.Age);
        Console.WriteLine(string.Join(" ", newList1));

    }
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

    public static IEnumerable<int> Top(this IEnumerable<int> items, double X, PersonExtractor person)
    {
        return items;
    }

    public delegate string PersonExtractor(int person);

    class Person
    {
        public int Age { get; set; }
    }
}
