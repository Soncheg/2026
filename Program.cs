using System;

namespace Task1_BasicConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Задание 1 - Базовые понятия C#";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    ЗАДАНИЕ 1 - БАЗОВЫЕ ПОНЯТИЯ C#                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                           ГЛАВНОЕ МЕНЮ                               ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("  1. Вычислить a^n (только умножение)");
                Console.WriteLine("  2. Перестановка второй цифры числа");
                Console.WriteLine("  3. Выйти из программы");
                Console.WriteLine();
                Console.Write("  Выберите опцию: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculatePower();
                        break;
                    case "2":
                        RearrangeSecondDigit();
                        break;
                    case "3":
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n  До свидания!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n  ❌ Неверный выбор! Нажмите любую клавишу...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Метод для вычисления a^n с использованием только умножения
        /// </summary>
        static void CalculatePower()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      ВЫЧИСЛЕНИЕ a^n                                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            int a, n;

            // Ввод числа a с проверкой
            while (true)
            {
                Console.Write("  Введите основание a (натуральное число): ");
                if (int.TryParse(Console.ReadLine(), out a) && a > 0)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ❌ Ошибка: введите натуральное число (a > 0)");
                Console.ResetColor();
            }

            // Ввод степени n с проверкой
            while (true)
            {
                Console.Write("  Введите степень n (натуральное число): ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ❌ Ошибка: введите натуральное число (n > 0)");
                Console.ResetColor();
            }

            // Вычисление a^n с использованием только умножения
            long result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= a; // Только умножение
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ Результат: {a}^{n} = {result}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод для перестановки второй цифры числа
        /// </summary>
        static void RearrangeSecondDigit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   ПЕРЕСТАНОВКА ВТОРОЙ ЦИФРЫ ЧИСЛА                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            int x;

            // Ввод числа x с проверкой (x >= 100)
            while (true)
            {
                Console.Write("  Введите число x (x >= 100): ");
                if (int.TryParse(Console.ReadLine(), out x) && x >= 100)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ❌ Ошибка: введите число больше или равное 100");
                Console.ResetColor();
            }

            // Получаем строковое представление числа
            string xStr = x.ToString();
            char secondDigit = xStr[1]; // Вторая цифра (индекс 1)

            // Формируем новое число
            string newNumberStr = xStr[0] + xStr.Substring(2);
            newNumberStr += secondDigit;

            int n = int.Parse(newNumberStr);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Исходное число x = {x}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Полученное число n = {n}");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}