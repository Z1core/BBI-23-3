﻿using System;
class Program
{
    static void Main(string[] args)
    {
        string inputText = Console.ReadLine();
        string outputText = RemovePunctuation(inputText);
        Console.WriteLine(outputText);
    }

    static string RemovePunctuation(string text)
    {
        string result = "";
        foreach (char c in text)
        {
            if (!char.IsPunctuation(c))
            {
                result += c;
            }
        }
        return result;
    }
}