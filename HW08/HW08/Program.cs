using System;

namespace HW07
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            
            // Запускаем общий цикл обработки
            bool isOver = false;
            while (!isOver)
            {
                while (true)
                {
                    Console.Write("Введите имя сотрудника. Для окончания ввода введите пустую строку: ");
                    var name = Console.ReadLine();
                    // Проверка на пустую строку для завершения ввода
                    if (name == "")
                    {
                        break;
                    }

                    // Парсим зарплату
                    var salary = 0;
                    Console.Write("Введите зарплату сотрудника: ");
                    while (!Int32.TryParse(Console.ReadLine(), out salary))
                    {
                        Console.Write("Некорректный ввод! Введите зарплату сотрудника: ");
                    }

                    // Создаем новую вершину
                    if (root == null)
                    {
                        root = new Node
                        {
                            Name = name,
                            Salary = salary
                        };
                    }
                    else
                    {
                        AddNode(root, new Node
                        {
                            Name = name,
                            Salary = salary
                        });
                    }
                }

                // Выводи отсортированный массив
                Console.WriteLine();
                Console.WriteLine("Выводим отсортированный список сотрудников: ");
                Traverse(root);


                // Обработка поиска сотрудника
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine();
                    Console.Write("Введите зарплату для поиска сотрудника: ");
                    var needle = 0;
                    while (!Int32.TryParse(Console.ReadLine(), out needle))
                    {
                        Console.Write("Некорректный ввод! Введите зарплату сотрудника для поиска: ");
                    }
                    
                    var (node, level) = Find(root, needle, level: 1);
                    if (node != null)
                    {
                        Console.WriteLine($"Нашли сотрудника: {node.Name} с зарплатой {node.Salary} за {level} шага(ов)");
                    }
                    else
                    {
                        Console.WriteLine("Такой сотрудник не найден");
                    }

                    // Обработка дальнейшего перехода
                    Console.WriteLine();
                    Console.Write("0 - для перехода к начала программы, 1 - для поиска сотрудника, q - для выхода из программы: ");
                    var userInput = Console.ReadLine();
                    while (userInput != "0" && userInput != "1" && userInput != "q")
                    {
                        Console.Write("Нажмите 0 или 1 для продолжения: ");
                        userInput = Console.ReadLine();                                                
                    }
                    
                    // Обработка переходов
                    switch (userInput)
                    {
                        case "0":
                            Console.WriteLine();
                            Console.WriteLine("Переходим к началу программы");
                            Console.WriteLine("----------------------------");
                            flag = false;
                            break;
                        case "1":
                            break;
                        case "q":
                            flag = false;
                            isOver = true;
                            break;
                    }
                }
            }
        }

        // Метод поиска вершины
        public static (Node node, int level) Find(Node node, double needle, int level)
        {
            if (needle < node.Salary)
            {
                // Ищем в левом поддереве
                if (node.Left == null)
                {
                    return (null, -1);
                }
                return Find(node.Left, needle, level + 1);
            }
            else if (needle > node.Salary)
            {
                // Ищем в правом поддереве
                if (node.Right == null)
                {
                    return (null, -1);
                }
                return Find(node.Right, needle, level + 1);
            }
            else
            {
                return (node, level);
            }
        }

        // Метод добавления вершины в поддеревья
        public static void AddNode(Node node, Node toAdd)
        {
            if (toAdd.Salary < node.Salary)
            {
                // Добавляем в левое поддерево
                if (node.Left == null)
                {
                    node.Left = toAdd;
                }
                else
                {
                    AddNode(node.Left, toAdd);
                }
            }
            else
            {
                // Добавляем в правое поддерево
                if (node.Right == null)
                {
                    node.Right = toAdd;
                }
                else
                {
                    AddNode(node.Right, toAdd);
                }
            }
        }

        //Метод вывода массива (симметричный метод)
        public static void Traverse(Node node)
        {
            if (node.Left != null)
            {
                Traverse(node.Left);
            }

            Console.WriteLine(node.Name + "-" + node.Salary);

            if (node.Right != null)
            {
                Traverse(node.Right);
            }
        }
    }

    //Описание класса Node
    class Node
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}