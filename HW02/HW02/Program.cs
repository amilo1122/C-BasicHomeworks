//инициализируем переменные
bool isParsed = false;
int n = 0;
int tableWidth = 0;
int tableHeight = 0;
var inputString = "";

//запрашиваем и обрабатываем размерность таблицы
Console.Write("Введите размерность таблицы от 1 до 6: ");
do
{
    isParsed = Int32.TryParse(Console.ReadLine(), out n);

    if (isParsed && n >= 1 && n <= 6)
    {
        Console.WriteLine($"n = {n}");
        break;
    }
    else
    {
        Console.Write("Ошибка! Введите корректное число: ");
    }
} while (!isParsed || n < 1 || n > 6);

//запрашиваем и обрабатываем входную стоку
Console.Write("Введите произвольный текст: ");
do
{
    inputString = Console.ReadLine();
    if (inputString.Length > 0 && (inputString.Length + n * 2) <= 40)
    {
        tableWidth = inputString.Length + (n * 2);
        tableHeight = (n * 2) + 1;
        //Console.WriteLine($"inputString length = {inputString.Length}");
        //Console.WriteLine($"tableWidth = {tableWidth}");
        break;
    }
    else
    {
        Console.Write("Введите корректную строку: ");
    }
}
while (inputString.Length < 1 || (inputString.Length + n * 2) > 40);

//выводим первую часть таблицы
var str = new String('+', tableWidth);
Console.WriteLine(str);
int i = 0;
while (i != tableHeight - 2)
{
    if (i == (tableHeight - n - 2))
    {
        Console.WriteLine("+" + new string(' ', n - 1) + new string(inputString) + new String(' ', n - 1) + "+");
        i++;
        continue;
    }
    Console.WriteLine("+" + new string(' ', tableWidth - 2) + "+");
    i++;
}
Console.WriteLine(str);

//выводим вторую часть таблицы
i = 0;
while (i != tableHeight - 2)
{
    if (i % 2 == 0)
    {
        for (int j = 0; j < tableWidth; j++)
        {
            if (j % 2 == 0)
            {                
                Console.Write("+");
            }
            else
            {
                if (j == 0 || j == tableWidth - 1)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write(" ");
                }
                
            }
        }
        i++;
    }
    else
    {
        for (int j = 0; j < tableWidth; j++)
        {
            if (j % 2 == 0)
            {
                if (j == 0 || j == tableWidth - 1)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write(" ");
                }    
            }
            else
            {
                Console.Write("+");
            }
        }
        i++;
    }
    Console.WriteLine();
}
Console.WriteLine(str);

//выводим третью часть таблицы
i = 0;
while (i != tableWidth - 2)
{
    for(int j = 0; j < tableWidth; j++)
    {
        if (j == 0 || j == tableWidth - 2)
        {
            Console.Write("+");
        }
        if (j == i || j == tableWidth - 3 - i)
        {
            Console.Write("+");
        }
        else
        {
            Console.Write(" ");
        }
    }
    i++;
    Console.WriteLine();
}
Console.WriteLine(str);

