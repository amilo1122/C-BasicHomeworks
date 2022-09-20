namespace HW062;

class Program
{
    static void Main(string[] args)
    {
        // Создаем 3 объекта класса Planet
        Planet Venus = new Planet("Венера", 2, 38025, null);
        Planet Earth = new Planet("Земля", 3, 40075, null);
        Planet Mars = new Planet("Марс", 4, 21344, null);

        // Помещаем объекты в массив
        Planet[] planetsArray = { Venus, Earth, Mars };

        // Инициализируем экземпляр класса и передаем в конструктор массив планет
        PlanetCatalog planetCatalog = new PlanetCatalog(planetsArray);

        // Создаем массив объектов для поиска
        string[] planetList = { "Венера", "Лимония", "Марс" };

        // Выводим объекты в консоль
        foreach (string planet in planetList)
        {
            PrintPlanetInfo(planetCatalog.GetPlanet(planet), planet);
        }
    }

    // Метод для вывода объектов в консоль
    private static void PrintPlanetInfo((int serialNumber, int equatorLength, string errorMessage) value, string planetName)
    {
        if (value.serialNumber > 0)
        {
            Console.WriteLine($"Планета - {planetName}, порядковый номер - {value.serialNumber}, длинна экватора - {value.equatorLength}");
        }
        else
        {
            Console.WriteLine(value.errorMessage);
        }
    }

    // Описываем класс Planet
    public class Planet
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public int EquatorLength { get; set; }
        public Planet PrevPlanet { get; set; }

        // Конструктор
        public Planet(string name, int serialNumber, int equatorLength, Planet prevPlanet)
        {
            Name = name;
            SerialNumber = serialNumber;
            EquatorLength = equatorLength;
            PrevPlanet = prevPlanet;
        }
    }

    // Описываем класс PlanetCatalog
    public class PlanetCatalog
    {
        // Создаем список для хранения объектов
        private List<Planet> _planets = new List<Planet>();
        // Создаем счетчик запросов
        private int counter = 0;

        // В конструкторе инициализируем список объектов
        public PlanetCatalog(Planet[] planets)
        {
            foreach (Planet planet in planets)
            {
                _planets.Add(planet);
            }
        }

        // Метод проверяет количество запросов и на каждый 3 вызов передает в 3 параметр котрежа соотсветствующее сообщение
        public (int serialNumber, int equatorLength, string errorMessage) GetPlanet(string name)
        {          
            counter++;
            if (counter == 3) return (serialNumber: 0, equatorLength: 0, errorMessage: "Вы слишком часто спрашиваете...");
            var planet = _planets.Find(planet => planet.Name == name);
            if (planet == null) return (serialNumber: 0, equatorLength: 0, errorMessage: "Не удалось найти планету...");
            return (serialNumber: planet.SerialNumber, equatorLength: planet.EquatorLength, errorMessage: "");
        }
    }
}