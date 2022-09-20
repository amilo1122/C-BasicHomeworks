try
{
    Calculate();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static void Calculate()
{
    var userInput = "";
    var arg1 = 0;
    var arg2 = 0;
    var sign = "";
    bool flag;
    while (userInput != "стоп")
    {
        //получаем входную стоку
        Console.Write("Введите выражение: ");
        userInput = Console.ReadLine();

        //отслеживаем код выхода 
        if (userInput != null && userInput != "стоп")
        {
            //вызываем функцию по обработке входной строки
            try
            {
                inputStringProcessing(userInput, out arg1, out sign, out arg2, out flag);
            }
            //обработка исключений
            catch (NoSignException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                flag = false;
            }
            catch (WrongSignException ex)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                flag = false;
            }
            catch (WrongExpressionException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                flag = false;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Не хватает операндов во входном массиве!");                
                flag = false;
            }
            catch (FormatException)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Операнд не является целым числом");
                Console.BackgroundColor = ConsoleColor.Black;
                flag = false;
            }
            catch (OverflowException)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Результат выражения вышел за границы int");
                Console.BackgroundColor = ConsoleColor.Black;
                flag = false;
            }
            catch
            {
                Console.WriteLine("Я не смог обработать ошибку");
                throw new Exception("В калькуляторе произошла ошибка: текст ошибки");
            }
            
            //проверка флага
            if (flag)
            {
                switch (sign)
                {
                    case "+":                        
                        try
                        {
                            Sum(arg1, arg2);
                        }
                        catch (Get13Exception ex)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(ex.Message);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch (OverflowException)
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Результат выражения вышел за границы int");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch
                        {
                            Console.WriteLine("Я не смог обработать ошибку");
                            throw new Exception("В калькуляторе произошла ошибка: текст ошибки");
                        }

                        break;
                    case "-":
                        try
                        {
                            Sub(arg1, arg2);
                        }
                        catch (Get13Exception ex)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(ex.Message);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch (OverflowException)
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Результат выражения вышел за границы int");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch
                        {
                            Console.WriteLine("Я не смог обработать ошибку");
                            throw new Exception("В калькуляторе произошла ошибка: текст ошибки");
                        }
                        break;
                    case "*":
                        try
                        {
                            Mul(arg1, arg2);
                        }
                        catch (Get13Exception ex)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(ex.Message);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch (OverflowException)
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Результат выражения вышел за границы int");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch
                        {
                            Console.WriteLine("Я не смог обработать ошибку");
                            throw new Exception("В калькуляторе произошла ошибка: текст ошибки");
                        }
                        break;
                    case "/":
                        try
                        {
                            Div(arg1, arg2);
                        }
                        catch (Get13Exception ex)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine(ex.Message);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Деление на ноль");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        catch
                        {
                            Console.WriteLine("Я не смог обработать ошибку");
                            throw new Exception("В калькуляторе произошла ошибка: текст ошибки");
                        }
                        break;
                }
            }
        }
        else
        {
            break;
        }
    }   
}

//обработка входной строки
static void inputStringProcessing(string userInput, out int arg1, out string sign, out int arg2, out bool flag)
{
    string[] input = userInput.Split(' ');
         
    arg1 = int.Parse(input[0]);

    //проверка для реализации условия кейса 1
    if (isNumeric(input[1]))
    {
        throw new NoSignException($"Укажите в выражении оператор: +, -, *, /");
    }

    //проверка для реализации условия кейса 2
    if (input[1] == "+" || input[1] == "-" || input[1] == "*" || input[1] == "/")
    {
        sign = input[1];
    }
    else
    {
        throw new ArgumentException($"Я пока не умею работать с оператором {input[1]}");
    }
    
    arg2 = int.Parse(input[2]);

    //проверка для реализации условия кейса 3
    if (input.Length != 3)
    {
        throw new ArgumentException("Выражение некорректное, попробуйте написать в формате \na + b\na - b\na * b\na / b");
    }

    flag = true;

}

static bool isNumeric(string str)
{
    bool isParsed = int.TryParse(str, out int result);
    return isParsed;
}

static void Div(int a, int b)
{
    checked
    {
        Console.WriteLine($"Ответ: {a / b}");
        if (a / b == 13)
        {
            throw new Get13Exception("Вы получили ответ 13!");
        }         
    }
}
static void Mul(int a, int b)
{
    checked
    {
        Console.WriteLine($"Ответ: {a * b}");
        if (a * b == 13)
        {
            throw new Get13Exception("Вы получили ответ 13!");
        }
    }
}
static void Sub(int a, int b)
{
    checked
    {
        Console.WriteLine($"Ответ: {a - b}");
        if (a - b == 13)
        {
            throw new Get13Exception("Вы получили ответ 13!");
        }
    }

}
static void Sum(int a, int b)
{
    checked
    {
        Console.WriteLine($"Ответ: {a + b}");
        if (a + b == 13)
        {
            throw new Get13Exception("Вы получили ответ 13!");
        }
    }

}

//создаем классы исключений
class NoSignException : Exception
{
    public NoSignException(string message)
        : base(message) { }
}
class WrongSignException : Exception
{
    public WrongSignException(string message)
        : base(message) { }
}
class WrongExpressionException : Exception
{
    public WrongExpressionException(string message)
        : base(message) { }
}
class Get13Exception : Exception
{
    public Get13Exception(string message)
        : base(message) { }
}