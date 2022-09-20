using System.Diagnostics;

namespace HW07;

class Program
{    static void Main(string[] args)
    {
        //создаем экземпляр класса
        FibonacciSequence sequence = new FibonacciSequence();
        //запускаем основной метод
        sequence.Show();
    }
}

//создаем делегат для работы с методами расчета последовательности Фибоначчи
delegate double Operation(int f);

class FibonacciSequence
{
    //создаем экземпляр класса для расчета времени выполнения
    Stopwatch stopWatch = new Stopwatch();
    //переменная для хранения запрошенного числа
    private int n;
    //создаем переменную для работы с делегатом
    private Operation? _selectedOperation;

    //Выводим основное меню
    private void PrintMenu()
    {
        Console.WriteLine(@"Выберите опцию:
1. Выбрать метод
2. Ввести аргументы
3. Вывести результат
4. Выход");
    }

    //Выводим меню выбора методов расчета
    private void PrintOperation()
    {
        Console.WriteLine(@"Выберите операцию:
1. Рекурсия
2. С помощью цикла");
    }

    //Выбор метода расчета
    private Operation GetOperation(int v)
    {
        switch (v)
        {
            case 1:
                return FibonacciRecursion;
            case 2:
                return FibonacciByLoop;
            default:
                return null;
        }
    }

    //Вывод результата
    private void PrintResult()
    {
        Console.WriteLine($"Запрошенное число: {n}");
        Console.WriteLine($"Результат операции: {_selectedOperation(n)}");        
    }

    //Расчет последовательности Фибоначчи с помощью рекурсии
    private double FibonacciRecursion(int index)
    {
        if (index == 0) return 0;
        if (index == 1) return 1;
        return FibonacciRecursion(index - 1) + FibonacciRecursion(index - 2);
    }

    //Расчет последовательности Фибоначчи итеративным способом
    private double FibonacciByLoop(int index)
    {
        int a = 0;
        int b = 1;
        int result = 0;
        for (int i = 1; i < index; i++)
        {
            if (index <= 1)
            {
                return i;
            }
            result = b + a;
            a = b;
            b = result;
        }
        return result;
    }

    //Основной метод
    public void Show()
    {
        while (true)
        {
            Console.Clear();
            PrintMenu();
            var c = Console.ReadKey();
            Console.Clear();
            switch (c.KeyChar)
            {
                case '1':
                    do
                    {
                        //Выводим меню выбора методов расчета
                        PrintOperation();
                        //Записываем выбранный метод
                        _selectedOperation = GetOperation(int.Parse(Console.ReadKey().KeyChar.ToString()));                        
                    }
                    while (_selectedOperation == null);
                    break;
                case '2':
                    //Запрашиваем число последовательности. Для сокращения кода отстствует проверка на некорректный ввод
                    Console.WriteLine("Введите аргумент:");
                    n = Int32.Parse(Console.ReadLine());
                    break;
                case '3':
                    //Мерием время выполнения операции
                    stopWatch.Start();
                    PrintResult();
                    stopWatch.Stop();
                    //Выводим время в консоль
                    TimeSpan ts = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);
                    Console.WriteLine("RunTime " + elapsedTime + " by " + _selectedOperation.Method.Name);
                    stopWatch.Restart();
                    Console.ReadKey();
                    break;
                case '4':
                    //Выход из программы
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

