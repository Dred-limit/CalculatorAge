using System;
using static System.Console;

class CalcalatorAge
{
    static void Main()
    {
        WriteLine("Введите свою дату рождения");
        string userDate = ReadLine();

        if (DateTime.TryParse(userDate, out DateTime birthday))
        {
            WriteLine($"Твоя дата рождения: {birthday:d}");
            if (birthday > DateTime.Today)
            {
                WriteLine("Ошибка: Ты из будущего? Введи коректную дату" +
                    " рождения, не позже сегодняшнего дня!");
                return;
            }
        }
        else
        {
            WriteLine("Ты написал неверный формат даты, попробуй: дд.мм.гггг");
            return;
        }

        DateTime today = DateTime.Today;
        int age = today.Year - birthday.Year;

        // Но нужно учесть, был ли день рождения в этом году
        if (today.Month < birthday.Month ||
            (today.Month == birthday.Month &&
            today.Day < birthday.Day))
        {
            age--; // День рождения еще не был в этом году
        }
        WriteLine($"Тебе {age} лет!");

        DateTime nextBirthday = new DateTime(today.Year, birthday.Month, birthday.Day);
        if (nextBirthday < today)
        {
            nextBirthday = nextBirthday.AddYears(1);
        }

        int daysUntilBirthday = (nextBirthday - today).Days;
        WriteLine($"До следующего дня рождения: {daysUntilBirthday} дней!");
    }
}