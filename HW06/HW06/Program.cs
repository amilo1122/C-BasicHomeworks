namespace HW061;

class Program
{   
    static void Main(string[] args)
    {
        // Создаем объеты анонимного типа
        var Venus = new
        {
            Name = "Венера",
            SerialNumber = 2,
            EquatorLength = 38025,
            PrevPlanet = (string)null,
        };
        var Earth = new
        {
            Name = "Земля",
            SerialNumber = 3,
            EquatorLength = 40075,
            PrevPlanet = Venus.Name,
        };
        var Mars = new
        {
            Name = "Марс",
            SerialNumber = 4,
            EquatorLength = 21344,
            PrevPlanet = Earth.Name,
        };
        var Venus2 = new
        {
            Name = "Венера",
            SerialNumber = 2,
            EquatorLength = 38025,
            PrevPlanet = (string)null,
        };

        // Выводим в консоль информацию о планетах и сравниваем их с Венерой
        Console.WriteLine(Venus);
        Console.WriteLine($"Планета эквивалентна Венере = {Venus.Equals(Venus)}");
        Console.WriteLine(Earth);
        Console.WriteLine($"Планета эквивалентна Венере = {Earth.Equals(Venus)}");
        Console.WriteLine(Mars);
        Console.WriteLine($"Планета эквивалентна Венере = {Mars.Equals(Venus)}");
        Console.WriteLine(Venus2);
        Console.WriteLine($"Планета эквивалентна Венере = {Venus2.Equals(Venus)}");

    }
     
}