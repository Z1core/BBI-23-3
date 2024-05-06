using System;
using System.Collections.Generic;

public struct Participant
{
    public string Name;
    public double BestJump;
}

class Program
{
    static void PrintParticipants(List<Participant> participants)
    {
        participants.Sort((x, y) => y.BestJump.CompareTo(x.BestJump));
        Console.WriteLine("Результаты соревнований по прыжкам в высоту:");
        foreach (var participant in participants)
        {
            Console.WriteLine($"Участник: {participant.Name}, лучший прыжок: {participant.BestJump} м");
        }
    }

    static void Main(string[] args)
    {
        List<Participant> participants = new List<Participant>();

        participants.Add(new Participant { Name = "Иванов", BestJump = 1.95 });
        participants.Add(new Participant { Name = "Петров", BestJump = 2.10 });
        participants.Add(new Participant { Name = "Сидоров", BestJump = 2.05 });
        participants.Add(new Participant { Name = "Смирнов", BestJump = 2.15 });
        participants.Add(new Participant { Name = "Кузнецов", BestJump = 2.20 });

        PrintParticipants(participants);
    }
}

