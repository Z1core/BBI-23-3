using System;
using System.Collections.Generic;

public struct Participant
{
    public string Name { get; private set; } // Сделал объявления св-ва приватным
    public double BestJump { get; private set; } // Сделал объявления св-ва приватным

    public Participant(string name, double bestJump) // Добавил конструктор для Participant
    {
        Name = name;
        BestJump = bestJump;
    }

    public void PrintParticipantInfo()
    {
        Console.WriteLine($"Участник: {Name}, лучший прыжок: {BestJump} м");
    }
}

class Program
{
    static void PrintParticipants(List<Participant> participants)
    {
        participants.Sort((x, y) => y.BestJump.CompareTo(x.BestJump));
        Console.WriteLine("Результаты соревнований по прыжкам в высоту:");
        foreach (var participant in participants)
        {
            participant.PrintParticipantInfo();
        }
    }

    static void Main(string[] args)
    {
        List<Participant> participants = new List<Participant>();

        participants.Add(new Participant("Иванов", 1.95)); 
        participants.Add(new Participant("Петров", 2.10)); 
        participants.Add(new Participant("Сидоров", 2.05)); 
        participants.Add(new Participant("Смирнов", 2.15)); 
        participants.Add(new Participant("Кузнецов", 2.20)); 

        PrintParticipants(participants);
    }
}
