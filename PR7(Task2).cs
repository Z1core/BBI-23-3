using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Person
{
    public string Name { get; set; }
    public int ID { get; set; }

    public Person(string name, int id)
    {
        Name = name;
        ID = id;
    }
    public abstract double CalculateAverageGrade();
}

public class Student : Person
{
    public int MathGrade { get; set; }
    public int PhysicsGrade { get; set; }
    public int RussianGrade { get; set; }

    public Student(string name, int id, int mathGrade, int physicsGrade, int russianGrade) : base(name, id)
    {
        MathGrade = mathGrade;
        PhysicsGrade = physicsGrade;
        RussianGrade = russianGrade;
    }

    public override double CalculateAverageGrade()
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
        Console.WriteLine("ФИО\tID\tСредний балл");
        foreach (var student in successfulStudents)
        {
            Console.WriteLine($"{student.Name}\t{student.ID}\t{student.CalculateAverageGrade()}");
        }
    }

    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student("Иванов", 1, 4, 5, 3),
            new Student("Петров", 2, 5, 4, 5),
            new Student("Сидоров", 3, 3, 4, 4),
            new Student("Смирнов", 4, 4, 3, 5),
            new Student("Кузнецов", 5, 5, 5, 4)
        };
        PrintSuccessfulStudents(students);
    }
}
