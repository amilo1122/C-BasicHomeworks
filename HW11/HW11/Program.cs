namespace HW11;

class Program
{
    static void Main(string[] args)
    {
        // Создаем экземпляр класса
        var dict = new OtusDictionary();
        
        // Вечный цикл для демонстрации работы со словарем. Для ускорения времени не обернут в TryParse
        while (true)
        {
            Console.WriteLine("Введите пару ключ-значение через :");
            string userInput = Console.ReadLine();
            var pair = userInput.Split(":");
            dict.Add(Int32.Parse(pair[0]), pair[1]);
            Console.WriteLine("Для поиска значения введите ключ:");
            var key = Int32.Parse(Console.ReadLine());
            Console.WriteLine(dict.Get(key));
        }
    }
    // Создаем класс Dict
    class Dict
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    // Основной класс
    class OtusDictionary
    {
        // Задаем размерность массива по-умолчанию
        private static int capacity = 32;
        private Dict[] Dict;


        // Описываем индексатор
        public Dict this[int i]
        {
            get { return GetObject(i); }
            set { Add(value.Key, value.Value); }
        }

        // Инициализируем массив в конструкторе
        public OtusDictionary()
        {
            Dict = new Dict[capacity];
        }

        // Реализуем метод Add на основе хэша ключа, если хеш ключа занят, увеличиваем массив вдвое
        public void Add(int key, string value)
        {
            int index = key % capacity;
            if (value == null)
            {
                throw new ArgumentNullException("Value cannot be null");
            }
            if (Dict[index] != null)
            {
                if (Dict[index].Key != key)
                {
                    ResizeArray();
                }
                else
                {
                    throw new ArgumentException("Dublicate key");
                }
                index = key % capacity;
            }
            var currentPair = new Dict();
            currentPair.Key = key;
            currentPair.Value = value;
            Dict[index] = currentPair;
        }

        // Реализуем метод Get, кидаем exception, если запрошенного ключа не существует
        public string? Get(int key)
        {
            int index = key % capacity;
            if (Dict[index] != null)
            {
                return Dict[index].Value;
            }
            throw new ArgumentException("The given key was not present in the dictionary");
        }

        // Реализуем приватный метод для возврата объекта словаря для индексатора
        private Dict GetObject(int key)
        {
            int index = key % capacity;
            if (Dict[index] != null)
            {
                return Dict[index];
            }
            throw new ArgumentException("The given key was not present in the dictionary");
        }

        // Реализуем функцию расширения массива и переиндексируем записи
        private void ResizeArray()
        {
            capacity *= 2;
            Dict[] newDict = new Dict[capacity];
            foreach (var item in Dict)
            {
                string value = item.Value;
                int index = item.Key % capacity;
                newDict[index].Key = item.Key;
                newDict[index].Value = value;
            }
            Dict = newDict;            
        }
    }
}