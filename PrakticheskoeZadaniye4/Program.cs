using System;
namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op) // присвоение вводимым числам тип данных "double"
        {
            double result = double.NaN; // Если используемое по умолчанию значение - " не число", которое мы используем, то при использовании операции деления, может выдать ошибку 

            switch (op) // используем оператор свитч для выполнения математических операций(сложение, вычитание, умножение, деление)
            {
                case "a": //условный оператор, если значение вводимых данных равно "а"
                    result = num1 + num2;
                    break; // завершилось выполнение блока команд
                case "s": //условный оператор, если значение вводимых данных равно "s"
                    result = num1 - num2;
                    break; // завершилось выполнение блока команд
                case "m": //условный оператор, если значение вводимых данных равно "m"
                    result = num1 * num2;
                    break; // завершилось выполнение блока команд
                case "d": //условный оператор, если значение вводимых данных равно "d"

                    if (num2 != 0) // условие, при котором запрещен ввод пользователем нулевого делителя
                    {
                        result = num1 / num2;
                    }
                    break;
                // Возвращаем текст для неверного ввода 
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Console Calculator in C#\r"); // Отображение названия нашего калькулятора
            Console.WriteLine("------------------------\n"); // Отображение указанной строки ниже названия калькулятора
            while (!endApp)
            {

                string numInput1 = ""; // Объявление переменной, которая будет "пустая"
                string numInput2 = ""; // Объявление переменной, которая будет "пустая"
                double result = 0;

                Console.Write("Type a number, and then press Enter: "); // Ввод пользователем первого числа
                numInput1 = Console.ReadLine(); // Считыаание первого числа, которое ввел пользователь 
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: "); // Ввод пользователем второго числа
                numInput2 = Console.ReadLine(); // Считывание второго числа, которое ввел вользователь
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2)) // цикл while
                {
                    Console.Write("This is not valid input. Please enter an integer value: "); // Вывод строки "...". Ввод пользователем корректного значения
                    numInput2 = Console.ReadLine(); // Считывание
                }
                // Выбор пользователем оператора(в нашем случае математическую операцию)
                Console.WriteLine("Choose an operator from the following list:"); // Вывод строки "..." на экран.
                Console.WriteLine("\ta - Add"); // математическая операция (сложение) 
                Console.WriteLine("\ts - Subtract"); // математическая операция (разность) 
                Console.WriteLine("\tm - Multiply"); // математическая операция (умножение) 
                Console.WriteLine("\td - Divide"); // математическая операция (деление) 
                Console.Write("Your option? "); // Вывод на экран строки "...". Ввод пользователем нужной ему математической операции
                string op = Console.ReadLine(); // Считывание значения, введенного пользователем
                try // блок обработки исключительных ситуаций, возникших при выполнении нашего кода
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result); // форматированный вывод
                }
                catch (Exception e) //блок обработки исключительных ситуаций, возникших при выполнении нашего кода
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
                Console.WriteLine("------------------------\n");
                // Подождать, пока пользователь в поле ввода введет n и нажмет Enter перед закрытием
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true; // Конструкция if выполняет блок кода, если заданное условие — истинно, т. е. true
                Console.WriteLine("\n"); //
            }
            return;
        }
    }
}
