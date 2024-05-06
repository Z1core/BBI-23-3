using System;
using System.Collections.Generic;
using System.Linq;

public struct FootballTeam
{
    public string Name;
    public int GoalsScored;
    public int GoalsConceded;
    public int Points;
    public FootballTeam(string name, int goalsScored, int goalsConceded, int points)
    {
        Name = name;
        GoalsScored = goalsScored;
        GoalsConceded = goalsConceded;
        Points = points;
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
            Console.WriteLine($"Место: {position}, Команда: {team.Name}, Очки: {team.Points}");
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
