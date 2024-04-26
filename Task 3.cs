using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        string answersPath = downloadsPath + "\\Answers";

        if (!Directory.Exists(answersPath))
        {
            Directory.CreateDirectory(answersPath);
            Console.WriteLine("Директория 'Answers' успешно создана.");
        }
        else
        {
            Console.WriteLine("Директория 'Answers' уже существует.");
        }

        string cw1Path = answersPath + "\\cw_1.json";
        if (!File.Exists(cw1Path))
        {
            File.Create(cw1Path).Close();
            Console.WriteLine("Файл 'cw_1.json' успешно создана.");
        }
        else
        {
            Console.WriteLine("Файл 'cw_1.json' уже существует.");
        }

        string cw2Path = answersPath + "\\cw_2.json";
        if (!File.Exists(cw2Path))
        {
            File.Create(cw2Path).Close();
            Console.WriteLine("Файл 'cw_2.json' успешно создана.");
        }
        else
        {
            Console.WriteLine("Файл 'cw_2.json' уже существует.");
        }
    }
}
