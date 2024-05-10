using System;
using System.Collections.Generic;
using System.Linq;

public struct Student
{
    public string Name { get; private set; } // Сделал объявления св-ва приватным
    public int MathGrade { get; private set; } // Сделал объявления св-ва приватным
    public int PhysicsGrade { get; private set; } // Сделал объявления св-ва приватным
    public int RussianGrade { get; private set; } // Сделал объявления св-ва приватным

    public Student(string name, int mathGrade, int physicsGrade, int russianGrade) // Добавил конструктор для Student
    {
        Name = name;
        MathGrade = mathGrade;
        PhysicsGrade = physicsGrade;
        RussianGrade = russianGrade;
    }

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
            new Student("Иванов", 4, 5, 3),
            new Student("Петров", 5, 4, 5),
            new Student("Сидоров", 3, 4, 4),
            new Student("Смирнов", 4, 3, 5),
            new Student("Кузнецов", 5, 5, 4)
        };

        PrintSuccessfulStudents(students);
    }
}
