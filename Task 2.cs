using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputText = Console.ReadLine();
        string outputText = ReverseSentences(inputText);
        Console.WriteLine(outputText);
    }

    static string ReverseSentences(string text)
    {
        string pattern = @"(?<=\.|\?|!)\s+";

        string[] sentences = Regex.Split(text, pattern);

        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = ReverseSentence(sentences[i]);
        }

        string result = string.Join("", sentences);
        return result;
    }

    static string ReverseSentence(string sentence)
    {
        string[] words = sentence.Split(' ');

        Array.Reverse(words);

        string reversedSentence = string.Join(" ", words);

        return reversedSentence;
    }
}
