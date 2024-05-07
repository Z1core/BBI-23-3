using System;
using System.Collections.Generic;
using System.Linq;

public abstract class FootballTeam
{
    public string Name { get; set; }
    public int Points { get; set; }

    public FootballTeam(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void PlayMatch();
}

public class WomenFootballTeam : FootballTeam
{
    public WomenFootballTeam(int teamNumber, int points) : base($"Женская команда {teamNumber}", points)
    {
    }
    public override void PlayMatch()
    {
        Console.WriteLine($"Матч для женской команды {Name} проведен.");
    }
}

public class MenFootballTeam : FootballTeam
{
    public MenFootballTeam(int teamNumber, int points) : base($"Мужская команда {teamNumber}", points)
    {
    }
    public override void PlayMatch()
    {
        Console.WriteLine($"Матч для мужской команды {Name} проведен.");
    }
}

public class Program
{
    static void PrintResultsTable(List<FootballTeam> teams)
    {
        teams = teams.OrderByDescending(team => team.Points).ToList();

        Console.WriteLine("Таблица результатов:");
        int position = 1;
        foreach (var team in teams)
        {
            string gender = GetGender(team);
            Console.WriteLine($"{position}. {team.Name} {gender} команда {team.Points} баллов");
            position++;
        }
    }

    static string GetGender(FootballTeam team)
    {
        if (team is WomenFootballTeam)
            return "женская";
        else if (team is MenFootballTeam)
            return "мужская";
        else
            return "";
    }

    static void Main(string[] args)
    {
        List<FootballTeam> allTeams = new List<FootballTeam>();

        List<FootballTeam> womenTeams = new List<FootballTeam>
        {
            new WomenFootballTeam(1, 13),
            new WomenFootballTeam(2, 10),
            new WomenFootballTeam(3, 11),
            new WomenFootballTeam(4, 9),
            new WomenFootballTeam(5, 12),
        };

        List<FootballTeam> menTeams = new List<FootballTeam>
        {
            new MenFootballTeam(6, 15),
            new MenFootballTeam(7, 10),
            new MenFootballTeam(8, 9),
            new MenFootballTeam(9, 8),
            new MenFootballTeam(10, 12),
        };

        allTeams.AddRange(womenTeams);
        allTeams.AddRange(menTeams);

        PrintResultsTable(allTeams);
    }
}
