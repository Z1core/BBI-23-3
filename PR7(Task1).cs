using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Participant
{
    public string Name { get; set; }
    public bool Disqualified { get; set; }

    public Participant(string name)
    {
        Name = name;
        Disqualified = false;
    }

    public abstract void Disqualify();
}

public class JumpParticipant : Participant
{
    public double BestJump { get; set; }

    public JumpParticipant(string name, double bestJump) : base(name)
    {
        BestJump = bestJump;
    }

    public override void Disqualify()
    {
        Disqualified = true;
    }
}

class Program
{
    static void PrintParticipants(List<Participant> participants)
    {
        var qualifiedParticipants = participants.Where(p => !p.Disqualified);

        var sortedParticipants = qualifiedParticipants.OrderByDescending(p =>
        {
            if (p is JumpParticipant jumpParticipant)
                return jumpParticipant.BestJump;
            return 0;
        });

        Console.WriteLine("Результаты соревнований по прыжкам в высоту:");
        foreach (var participant in sortedParticipants)
        {
            if (participant is JumpParticipant jumpParticipant)
            {
                Console.WriteLine($"Участник: {jumpParticipant.Name}, лучший прыжок: {jumpParticipant.BestJump} м");
            }
        }
    }

    static void Main(string[] args)
    {
        List<Participant> participants = new List<Participant>();

        participants.Add(new JumpParticipant("Иванов", 1.95));
        participants.Add(new JumpParticipant("Петров", 2.10));
        participants.Add(new JumpParticipant("Сидоров", 2.05));
        participants.Add(new JumpParticipant("Смирнов", 2.15));
        participants.Add(new JumpParticipant("Кузнецов", 2.20));

        participants[0].Disqualify();

        PrintParticipants(participants);
    }
}
