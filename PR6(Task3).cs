using System;
using System.Collections.Generic;
using System.Linq;

public struct FootballTeam
{
    public string Name { get; private set; } // Сделал объявления св-ва приватным
    public int GoalsScored { get; private set; } // Сделал объявления св-ва приватным
    public int GoalsConceded { get; private set; } // Сделал объявления св-ва приватным
    public int Points { get; private set; } // Сделал объявления св-ва приватным

    public FootballTeam(string name, int goalsScored, int goalsConceded, int points) // Добавил конструктор для FootballTeam
    {
        Name = name;
        GoalsScored = goalsScored;
        GoalsConceded = goalsConceded;
        Points = points;
    }

    public void PrintResults()
    {
        Console.WriteLine($"Команда: {Name}, Забито голов: {GoalsScored}, Пропущено голов: {GoalsConceded}, Очки: {Points}");
    }
}

public class Program
{
    static void PrintResultsTable(List<FootballTeam> teams)
    {
        teams = teams.OrderByDescending(team => team.Points).ThenByDescending(team => team.GoalsScored - team.GoalsConceded).ToList();

        Console.WriteLine("Таблица результатов:");
        int position = 1;
        foreach (var team in teams)
        {
            Console.WriteLine($"Место: {position}");
            team.PrintResults();
            position++;
        }
    }

    static void Main(string[] args)
    {
        List<FootballTeam> teams = new List<FootballTeam>
        {
            new FootballTeam("Команда1", 10, 5, 9),
            new FootballTeam("Команда2", 8, 7, 7),
            new FootballTeam("Команда3", 6, 8, 5),
            new FootballTeam("Команда4", 4, 9, 3),
            new FootballTeam("Команда5", 7, 6, 7)
        };

        PrintResultsTable(teams);
    }
}
