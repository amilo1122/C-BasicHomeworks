namespace HW063;

class Program
{
    static void Main(string[] args)
    {
        // Создаем 3 объекта класса Planet
        Planet Venus = new Planet("Венера", 2, 38025, null);
        Planet Earth = new Planet("Земля", 3, 40075, null);
        Planet Mars = new Planet("Марс", 4, 21344, null);

        // Помещаем объекты в массив
        Planet[] planetsArray = {Venus, Earth, Mars};
        // Создаем счетчик запросов
        int counter = 0;

        // Инициализируем экземпляр класса и передаем в конструктор массив планет
        PlanetCatalog planetCatalog = new PlanetCatalog(planetsArray);
        string[] planetList = { "Венера", "Лимония", "Марс" };

        // Выводим объекты в консоль
        foreach (string planetName in planetList)
        {
            counter++;
            // В метод GetPlanet передаем лямбду для обработки каждого 3-го вызова
            var planet = planetCatalog.GetPlanet(planetName, planetName =>
            {
                if (counter == 3)
                {
                    return "Вы слишком часто спрашиваете...";
                }
                else
                {
                    return null;
                }
            }
            );
            // Проверяем выходной параметр анонимного метода
            if (planet.errorMessage == "")
            {
                Console.WriteLine($"Планета - {planetName}, порядковый номер - {planet.serialNumber}, длинна экватора - {planet.equatorLength}");
            }
            else
            {
                Console.WriteLine(planet.errorMessage);
            }
        }
        // Обработка задания со звоздочкой
        Console.WriteLine("--------------");
        string[] planetList2 = { "Венера", "Марс", "Лимония", "Лимония" };
        counter = 0;

        foreach (string planetName in planetList2)
        {
            counter++;
            
            var planet = planetCatalog.GetPlanet(planetName, planetName =>
            {
                // В лямбде сначала проверяем счетчик вызовов
                if (counter == 3)
                {
                    return "Вы слишком часто спрашиваете...";
                }
                // Затем отлавливаем планету с названием "Лимония"
                if (planetName == "Лимония")
                {
                    return "Это запретная планета";
                }
                else
                {
                    return null;
                }
            }
            );
            // Проверяем выходной параметр анонимного метода
            if (planet.errorMessage == "")
            {
                Console.WriteLine($"Планета - {planetName}, порядковый номер - {planet.serialNumber}, длинна экватора - {planet.equatorLength}");
            }
            else
            {
                Console.WriteLine(planet.errorMessage);
            }
        }
    }
    // Создаем делегат
    public delegate string PlanetValidator(string errorMessage);

    //Описываем класс Planet
    public class Planet
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public int EquatorLength { get; set; }
        public Planet PrevPlanet { get; set; }

        public Planet(string name, int serialNumber, int equatorLength, Planet prevPlanet)
        {
            Name = name;
            SerialNumber = serialNumber;
            EquatorLength = equatorLength;
            PrevPlanet = prevPlanet;
        }
    }

    //Описываем класс PlanetCatalog
    public class PlanetCatalog
    {
        // Создаем список для хранения объектов
        private List<Planet> _planets = new List<Planet>();

        // В конструкторе инициализируем список объектов
        public PlanetCatalog(Planet[] planets)
        {
            foreach (Planet planet in planets)
            {
                _planets.Add(planet);
            }
        }

        // Добавляем в метод 2-ой параметр - делегат
        public (int serialNumber, int equatorLength, string errorMessage) GetPlanet(string name, PlanetValidator planetValidator)
        {
            // В делегат передаем входной параметр
            var errorMessage = planetValidator(name);
            // Обрабатываем выходной параметр делегата
            if (errorMessage != null) return (serialNumber: 0, equatorLength: 0, errorMessage: errorMessage);

            // Поиск запрошенной планеты
            var planet = _planets.Find(planet => planet.Name == name);
            // Возвращаем данные
            if (planet == null) return (serialNumber: 0, equatorLength: 0, errorMessage: "Не удалось найти планету...");
            return (serialNumber: planet.SerialNumber, equatorLength: planet.EquatorLength, errorMessage: "");
        }
    }
}