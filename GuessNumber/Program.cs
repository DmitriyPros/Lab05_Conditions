/*Console.Write("Введите число: ");
int number = int.Parse(Console.ReadLine());
if (number > 0)
{
    Console.WriteLine("Число положительное.");
}
else if (number < 0)
{
    Console.WriteLine("Число отрицательное.");
}
else
{
    Console.WriteLine("Число равно нулю.");
}

Console.Write("Введите балл (0-100): ");
int score = int.Parse(Console.ReadLine());
if (score >= 91)
{
    Console.WriteLine("Оценка: Отлично (5)");
}
else if (score >= 71)
{
    Console.WriteLine("Оценка: Хорошо (4)");
}
else if (score >= 51)
{
    Console.WriteLine("Оценка: Удовлетворительно (3)");
}
else
{
    Console.WriteLine("Оценка: Неудовлетворительно (2)");
}

Console.Write("Введите количество посещений (из 19): ");
int attendance = int.Parse(Console.ReadLine());
Console.Write("Введите средний балл по практике: ");
double practiceGpa = double.Parse(Console.ReadLine());
bool goodAttendance = attendance >= 14;
bool goodGrades = practiceGpa >= 3.0;
if (goodAttendance && goodGrades)
{
    Console.WriteLine("+ Допуск к экзамену разрешён!");
}
else if (!goodAttendance && goodGrades)
{
    Console.WriteLine("- Недостаточно посещений. Нужно отработать пропуски!");
}
else if (goodAttendance && !goodGrades)
{
    Console.WriteLine("- Низкий балл по практике. Нужно пересдать работы!");
}
else
{
    Console.WriteLine("- Проблемы и с посещаемостью, и с оценками! Бегом к преподавателю, бездарь!");
}

Console.Write("Введите ваш возраст: ");
int age = int.Parse(Console.ReadLine());
string ageGroup = age >= 18 ? "Совершеннолетний" : "Несовершеннолетний";
Console.WriteLine($"Вы {ageGroup}.");
Console.Write("\nВведите температуру за окном (°C): ");
double temp = double.Parse(Console.ReadLine());
string weather = temp >= 20 ? "тепло" : (temp >= 0 ? "прохладно" : "мороз");
Console.WriteLine($"За окном {weather}.");
Console.Write("\nВведите число: ");
int n = int.Parse(Console.ReadLine());
string parity = n % 2 == 0 ? "чётное" : "нечётное";
Console.WriteLine($"Число {n} - {parity}.");

Console.WriteLine("Меню");
Console.WriteLine("1. Посмотреть расписание");
Console.WriteLine("2. Посмотреть оценки");
Console.WriteLine("3. Связаться с преподавателем");
Console.WriteLine("4. Выйти");
Console.Write("Выберите пункт (1-4): ");
string choice = Console.ReadLine();
switch (choice)
{
    case "1":
        Console.WriteLine("Расписание: ИСП-241, каб. 1-02, 08:30");
        break;
    case "2":
        Console.WriteLine("Ваши оценки: ИСРПО-99, РПМ-102,");
        break;
    case "3":
        Console.WriteLine("Email: denis.leontev92@yandex.ru");
        break;
    case "4":
        Console.WriteLine("До свидания!");
        break;
    default:
        Console.WriteLine($"Ошибка: пункт <<{choice}>> не существует. Введите число от 1 до 4.");
        break;
}

Console.Write("\nВведите номер дня недели (1-7): ");
int dayNumber = int.Parse(Console.ReadLine());
switch (dayNumber)
{
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
        Console.WriteLine("Рабочий день - пора учиться!");
        break;
    case 6:
    case 7:
        Console.WriteLine("Выходной - заслуженный отдых.");
        break;
    default:
        Console.WriteLine("Такого дня не существует!");
        break;
}

Console.Write("\nВведите номер месяца (1-12): ");
int month = int.Parse(Console.ReadLine());
switch (month)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine("Зима");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("Весна");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("Лето");
        break;
    case 9:
    case 10:
    case 11:
        Console.WriteLine("Осень");
        break;
    default:
        Console.WriteLine("Такого месяца не существует!");
        break;
}*/

Random random = new Random();
int secret = random.Next(1, 101);
int attempts = 0;
bool guessed = false;
Console.WriteLine("Угадай число (1-100)");
Console.WriteLine("Я загадал число. Попробуй угадать!");
string result = attempts <= 7
    ? $"Отличный результат! Всего {attempts} попыток."
    : $"Число найдено за {attempts} попыток. Можно лучше!";
while (!guessed)
{
    Console.Write($"Попытка {attempts + 1}. Твой вариант: ");
    string input = Console.ReadLine();
    if (!int.TryParse(input, out int guess))
    {
        Console.WriteLine("!!! Введи целое число, а не текст!");
        continue;
    }
    if (guess < 1 || guess > 100)
    {
        Console.WriteLine("!!! Число должно быть от 1 до 100!");
        continue;
    }
    attempts++;
    if (guess < secret)
    {
        int diff = secret - guess;
        string hint = GetHint(diff);
        Console.WriteLine($"↑ Больше! {hint}\n");
    }
    else if (guess > secret)
    {
        int diff = guess - secret;
        string hint = GetHint(diff);
        Console.WriteLine($"↓ Меньше! {hint}\n");
    }
    else
    {
        guessed = true;
    }
}
Console.WriteLine($"� Правильно! Загаданное число: {secret}");
Console.WriteLine($"{result}");
string GetHint(int difference)
{
    switch (difference)
    {
        case <= 3:
            return "� Горячо!";
        case <= 10:
            return "� Тепло!";
        case <= 25:
            return "� Прохладно!";
        default:
            return "❄ Холодно!";
    }
}



