namespace HW11;

class Program
{
    static void Main(string[] args)
    {
        OtusDictionary dict = new OtusDictionary();
        
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

    class OtusDictionary
    {
        private static int capacity = 32;
        private int[] Keys;
        private string[] Values;

        public OtusDictionary()
        {
            Keys = new int[capacity];
            Values = new string[capacity];
        }

        public void Add(int key, string value)
        {
            int index = key % capacity;
            if (value == null)
            {
                throw new ArgumentNullException("Value cannot be null");
            }
            if (Values[index] != null)
            {
                if (Keys[index] != key)
                {
                    ResizeArray();
                }
                else
                {
                    throw new ArgumentException("Dublicate key");
                }
                index = key % capacity;
            }
            Keys[index] = key;
            Values[index] = value;
        }

        public string? Get(int key)
        {
            int index = key % capacity;
            if (Values[index] != null)
            {
                return Values[index];
            }
            throw new ArgumentException("The given key was not present in the dictionary");
        }

        private void ResizeArray()
        {
            capacity *= 2;
            int[] newKeys = new int[capacity];
            string[] newValues = new string[capacity];
            foreach (var key in Keys)
            {
                string value = Values[key];
                int index = key % capacity;
                newKeys[index] = key;
                newValues[index] = value;
            }
            Values = newValues;
            Keys = newKeys;
        }
    }
}