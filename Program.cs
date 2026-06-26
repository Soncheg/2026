using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_OOP
{
    /// <summary>
    /// Базовый абстрактный класс Animal
    /// </summary>
    public abstract class Animal
    {
        private string _name;
        private int _age;
        private string _habitat;
        private string _dietType;
        private double _weight;
        private string _color;

        protected Animal(string name, int age, string habitat, string dietType, double weight, string color)
        {
            Name = name;
            Age = age;
            Habitat = habitat;
            DietType = dietType;
            Weight = weight;
            Color = color;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Кличка не может быть пустой");
                _name = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 200)
                    throw new ArgumentException("Возраст должен быть в диапазоне 0-200 лет");
                _age = value;
            }
        }

        public string Habitat
        {
            get => _habitat;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Среда обитания не может быть пустой");
                _habitat = value;
            }
        }

        public string DietType
        {
            get => _dietType;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Тип питания не может быть пустым");
                _dietType = value;
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес должен быть положительным");
                _weight = value;
            }
        }

        public string Color
        {
            get => _color;
            set => _color = value ?? "неизвестно";
        }

        public virtual string GetInfo()
        {
            return $"Кличка: {Name}, Возраст: {Age}, Среда: {Habitat}, " +
                   $"Питание: {DietType}, Вес: {Weight} кг, Окрас: {Color}";
        }

        public abstract string GetAnimalType();
    }

    /// <summary>
    /// Класс Mammal (млекопитающее)
    /// </summary>
    public class Mammal : Animal
    {
        public bool HasFur { get; set; }

        public Mammal(string name, int age, string habitat, string dietType, double weight, string color, bool hasFur)
            : base(name, age, habitat, dietType, weight, color)
        {
            HasFur = hasFur;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Млекопитающее, Шерсть: {(HasFur ? "есть" : "нет")}";
        }

        public override string GetAnimalType() => "Млекопитающее";
    }

    /// <summary>
    /// Класс Bird (птица)
    /// </summary>
    public class Bird : Animal
    {
        public double WingSpan { get; set; }

        public Bird(string name, int age, string habitat, string dietType, double weight, string color, double wingSpan)
            : base(name, age, habitat, dietType, weight, color)
        {
            WingSpan = wingSpan;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Птица, Размах крыльев: {WingSpan:F2} м";
        }

        public override string GetAnimalType() => "Птица";
    }

    /// <summary>
    /// Класс Fish (рыба)
    /// </summary>
    public class Fish : Animal
    {
        public string WaterType { get; set; }

        public Fish(string name, int age, string habitat, string dietType, double weight, string color, string waterType)
            : base(name, age, habitat, dietType, weight, color)
        {
            WaterType = waterType;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Рыба, Вода: {WaterType}";
        }

        public override string GetAnimalType() => "Рыба";
    }

    /// <summary>
    /// Класс Reptile (пресмыкающееся)
    /// </summary>
    public class Reptile : Animal
    {
        public bool IsVenomous { get; set; }

        public Reptile(string name, int age, string habitat, string dietType, double weight, string color, bool isVenomous)
            : base(name, age, habitat, dietType, weight, color)
        {
            IsVenomous = isVenomous;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Пресмыкающееся, Ядовитость: {(IsVenomous ? "ядовитое" : "неядовитое")}";
        }

        public override string GetAnimalType() => "Пресмыкающееся";
    }

    /// <summary>
    /// Класс Amphibian (земноводное)
    /// </summary>
    public class Amphibian : Animal
    {
        public double SkinMoisture { get; set; }

        public Amphibian(string name, int age, string habitat, string dietType, double weight, string color, double skinMoisture)
            : base(name, age, habitat, dietType, weight, color)
        {
            SkinMoisture = skinMoisture;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Тип: Земноводное, Влажность кожи: {SkinMoisture:F1}%";
        }

        public override string GetAnimalType() => "Земноводное";
    }

    /// <summary>
    /// Класс AnimalManager (Singleton паттерн)
    /// </summary>
    public class AnimalManager
    {
        private static AnimalManager _instance;
        private static readonly object _lock = new object();
        private List<Animal> _animals;

        private AnimalManager()
        {
            _animals = new List<Animal>();
        }

        public static AnimalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AnimalManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void AddAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal), "Животное не может быть null");

            _animals.Add(animal);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ Животное '{animal.Name}' успешно добавлено!");
            Console.ResetColor();
        }

        public List<Animal> GetAllAnimals()
        {
            return new List<Animal>(_animals);
        }

        public Animal FindAnimalByName(string name)
        {
            return _animals.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Animal GetAnimalByIndex(int index)
        {
            if (index < 0 || index >= _animals.Count)
                throw new IndexOutOfRangeException($"Индекс должен быть от 0 до {_animals.Count - 1}");

            return _animals[index];
        }

        public void PrintAllAnimals()
        {
            if (_animals.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ⚠️ В зоопарке нет животных.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  Всего животных: {_animals.Count}\n");
            Console.ResetColor();

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  [{i + 1}]");
                Console.ResetColor();
                Console.WriteLine($"  {_animals[i].GetInfo()}");
                Console.WriteLine(new string('─', 70));
            }
        }

        public void PrintAnimalByName(string name)
        {
            Animal animal = FindAnimalByName(name);

            if (animal != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n  Информация о животном '{name}':");
                Console.ResetColor();
                Console.WriteLine($"  {animal.GetInfo()}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n  ❌ Животное с именем '{name}' не найдено.");
                Console.ResetColor();
            }
        }

        public int Count => _animals.Count;
    }

    /// <summary>
    /// Главный класс программы
    /// </summary>
    class Program
    {
        static AnimalManager _manager = AnimalManager.Instance;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Задание 2 - ООП на C#";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                         ЗАДАНИЕ 2 - ООП НА C#                         ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            // Создаем тестовых животных
            CreateTestAnimals();

            // Запускаем меню
            ShowMenu();
        }

        static void CreateTestAnimals()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Создание тестовых животных...");
            Console.ResetColor();

            try
            {
                Animal lion = new Mammal("Симба", 5, "саванна", "хищник", 180.5, "золотистый", true);
                Animal parrot = new Bird("Кеша", 3, "тропический лес", "всеядное", 0.8, "зеленый", 0.5);
                Animal shark = new Fish("Немо", 8, "океан", "хищник", 250.0, "серый", "морская");
                Animal snake = new Reptile("Каа", 4, "джунгли", "хищник", 15.2, "зеленый", true);
                Animal frog = new Amphibian("Квакша", 2, "болото", "насекомоядное", 0.3, "зеленый", 85.5);

                _manager.AddAnimal(lion);
                _manager.AddAnimal(parrot);
                _manager.AddAnimal(shark);
                _manager.AddAnimal(snake);
                _manager.AddAnimal(frog);

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  ❌ Ошибка при создании животных: {ex.Message}");
                Console.ResetColor();
            }
        }

        static void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                           ЗООПАРК МЕНЕДЖЕР                            ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine($"  Всего животных: {_manager.Count}");
                Console.WriteLine();
                Console.WriteLine("  1. Показать всех животных");
                Console.WriteLine("  2. Найти животное по имени");
                Console.WriteLine("  3. Добавить новое животное");
                Console.WriteLine("  4. Показать количество животных");
                Console.WriteLine("  5. Выйти из программы");
                Console.WriteLine();
                Console.Write("  Выберите опцию: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                        СПИСОК ВСЕХ ЖИВОТНЫХ                           ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
                        Console.ResetColor();
                        _manager.PrintAllAnimals();
                        Console.WriteLine();
                        Console.WriteLine("  Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                         ПОИСК ЖИВОТНОГО                               ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.Write("  Введите кличку животного: ");
                        string name = Console.ReadLine();
                        _manager.PrintAnimalByName(name);
                        Console.WriteLine();
                        Console.WriteLine("  Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case "3":
                        AddNewAnimal();
                        break;

                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                       КОЛИЧЕСТВО ЖИВОТНЫХ                             ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"  ✅ Количество животных в зоопарке: {_manager.Count}");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("  Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;

                    case "5":
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

        static void AddNewAnimal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       ДОБАВЛЕНИЕ ЖИВОТНОГО                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("  Выберите тип животного:");
            Console.WriteLine("  1. Млекопитающее");
            Console.WriteLine("  2. Птица");
            Console.WriteLine("  3. Рыба");
            Console.WriteLine("  4. Пресмыкающееся");
            Console.WriteLine("  5. Земноводное");
            Console.WriteLine("  6. Отмена");
            Console.WriteLine();
            Console.Write("  Ваш выбор: ");

            string typeChoice = Console.ReadLine();

            if (typeChoice == "6")
                return;

            try
            {
                Console.WriteLine();
                Console.Write("  Введите кличку: ");
                string name = Console.ReadLine();

                Console.Write("  Введите возраст: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("  Введите среду обитания: ");
                string habitat = Console.ReadLine();

                Console.Write("  Введите тип питания (хищник/травоядное/всеядное): ");
                string diet = Console.ReadLine();

                Console.Write("  Введите вес (кг): ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("  Введите окрас: ");
                string color = Console.ReadLine();

                Animal newAnimal = null;

                switch (typeChoice)
                {
                    case "1":
                        Console.Write("  Есть ли шерсть? (да/нет): ");
                        bool hasFur = Console.ReadLine().ToLower() == "да";
                        newAnimal = new Mammal(name, age, habitat, diet, weight, color, hasFur);
                        break;

                    case "2":
                        Console.Write("  Введите размах крыльев (м): ");
                        double wingSpan = double.Parse(Console.ReadLine());
                        newAnimal = new Bird(name, age, habitat, diet, weight, color, wingSpan);
                        break;

                    case "3":
                        Console.Write("  Введите тип воды (пресная/морская): ");
                        string waterType = Console.ReadLine();
                        newAnimal = new Fish(name, age, habitat, diet, weight, color, waterType);
                        break;

                    case "4":
                        Console.Write("  Ядовитое? (да/нет): ");
                        bool isVenomous = Console.ReadLine().ToLower() == "да";
                        newAnimal = new Reptile(name, age, habitat, diet, weight, color, isVenomous);
                        break;

                    case "5":
                        Console.Write("  Введите влажность кожи (%): ");
                        double moisture = double.Parse(Console.ReadLine());
                        newAnimal = new Amphibian(name, age, habitat, diet, weight, color, moisture);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("  ❌ Неверный тип животного!");
                        Console.ResetColor();
                        Console.ReadKey();
                        return;
                }

                if (newAnimal != null)
                {
                    _manager.AddAnimal(newAnimal);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("  Информация о добавленном животном:");
                    Console.ResetColor();
                    Console.WriteLine($"  {newAnimal.GetInfo()}");
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  ❌ Ошибка: неверный формат ввода. Проверьте введенные данные.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n  ❌ Ошибка: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n  ❌ Непредвиденная ошибка: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("  Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}