using System;
using System.Collections.Generic;
using System.Linq;

public struct Student
{
    public string Name;
    public int MathGrade;
    public int PhysicsGrade;
    public int RussianGrade;
    public double CalculateAverageGrade()
    {
        return (MathGrade + PhysicsGrade + RussianGrade) / 3.0;
    }
}

public class Program
{
    static void PrintSuccessfulStudents(List<Student> students)
    {
        var successfulStudents = students.Where(student => student.MathGrade != 2 && student.PhysicsGrade != 2 && student.RussianGrade != 2).OrderByDescending(student => student.CalculateAverageGrade());

        Console.WriteLine("Список успешных учащихся:");
        foreach (var student in successfulStudents)
        {
            Console.WriteLine($"Имя: {student.Name}, Средний балл: {student.CalculateAverageGrade()}");
        }
    }

    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Иванов", MathGrade = 4, PhysicsGrade = 5, RussianGrade = 3 },
            new Student { Name = "Петров", MathGrade = 5, PhysicsGrade = 4, RussianGrade = 5 },
            new Student { Name = "Сидоров", MathGrade = 3, PhysicsGrade = 4, RussianGrade = 4 },
            new Student { Name = "Смирнов", MathGrade = 4, PhysicsGrade = 3, RussianGrade = 5 },
            new Student { Name = "Кузнецов", MathGrade = 5, PhysicsGrade = 5, RussianGrade = 4 }
        };

        PrintSuccessfulStudents(students);
    }
}