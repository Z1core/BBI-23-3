using System;
using System.Collections.Generic;

public abstract class FootballTeam
{
    public string Name { get; private set; }
    public int Points { get; protected set; }

    public FootballTeam(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void PlayMatch(FootballTeam opponent, int ownGoals, int opponentGoals);
}

public class WomenFootballTeam : FootballTeam
{
    public WomenFootballTeam(int teamNumber, int points) : base($"Женская команда {teamNumber}", points)
    {
    }

    public override void PlayMatch(FootballTeam opponent, int ownGoals, int opponentGoals)
    {
        UpdateStats(ownGoals, opponentGoals);
    }

    private void UpdateStats(int ownGoals, int opponentGoals)
    {
        Points += ownGoals > opponentGoals ? 3 : ownGoals == opponentGoals ? 1 : 0;
    }
}

public class MenFootballTeam : FootballTeam
{
    public MenFootballTeam(int teamNumber, int points) : base($"Мужская команда {teamNumber}", points)
    {
    }

    public override void PlayMatch(FootballTeam opponent, int ownGoals, int opponentGoals)
    {
        UpdateStats(ownGoals, opponentGoals);
    }

    private void UpdateStats(int ownGoals, int opponentGoals)
    {
        Points += ownGoals > opponentGoals ? 3 : ownGoals == opponentGoals ? 1 : 0;
    }
}

public class Program
{
    static Random random = new Random();

    static void PrintResultsTable(List<FootballTeam> teams)
    {
        teams.Sort((team1, team2) => team2.Points.CompareTo(team1.Points));

        Console.WriteLine("Таблица результатов:");
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {teams[i].Name} команда {teams[i].Points} баллов");
        }
    }

    static void PlayMatches(List<FootballTeam> teams)
    {
        for (int i = 0; i < teams.Count; i++)
        {
            for (int j = i + 1; j < teams.Count; j++)
            {
                int ownGoals = random.Next(6);
                int opponentGoals = random.Next(6);
                teams[i].PlayMatch(teams[j], ownGoals, opponentGoals);
            }
        }
    }

    static void Main(string[] args)
    {
        List<FootballTeam> allTeams = new List<FootballTeam>();

        List<FootballTeam> womenTeams = new List<FootballTeam>
        {
            new WomenFootballTeam(1, 0),
            new WomenFootballTeam(2, 0),
            new WomenFootballTeam(3, 0),
            new WomenFootballTeam(4, 0),
        };

        List<FootballTeam> menTeams = new List<FootballTeam>
        {
            new MenFootballTeam(1, 0),
            new MenFootballTeam(2, 0),
            new MenFootballTeam(3, 0),
            new MenFootballTeam(4, 0),
        };

        allTeams.AddRange(womenTeams);
        allTeams.AddRange(menTeams);

        PlayMatches(allTeams);
        PrintResultsTable(allTeams);
    }
}
