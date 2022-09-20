namespace HW11;

class Program
{
    static void Main(string[] args)
    {
        var dict = new OtusDictionary();
      
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
    class Dict
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
    class OtusDictionary
    {
        private static int capacity = 32;
        private Dict[] Dict;

        //public Dict this[int i]
        //{
        //    get { return Dict[i]; }
        //    set { Dict[i] = value; }
        //}

        public OtusDictionary()
        {
            Dict = new Dict[capacity];
        }

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

        public string? Get(int key)
        {
            int index = key % capacity;
            if (Dict[index] != null)
            {
                return Dict[index].Value;
            }
            throw new ArgumentException("The given key was not present in the dictionary");
        }

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