using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

// Интерфейсы
public interface IEncryptionService { string Encrypt(string message); string Decrypt(string message); }
public interface IComplexityCalculator { int CalculateComplexity(string sentence); }
public interface ISyllableCounter { Dictionary<int, int> CountSyllables(string text); }
public interface ITextFormatter { List<string> FormatText(string text); }
public interface ITextCompressor { (string compressedText, Dictionary<string, string> codeTable) CompressText(string text); }
public interface ITextDecoder { string DecompressText(string compressedText, Dictionary<string, string> codeTable); }

// Реализации
public class ReverseWordEncryptionService : IEncryptionService
{
    public string Encrypt(string message) => string.Join(" ", message.Split(' ').Select(Reverse));
    public string Decrypt(string message) => Encrypt(message);
    private string Reverse(string input) => new string(input.Reverse().ToArray());
}

public class SentenceComplexityCalculator : IComplexityCalculator
{
    public int CalculateComplexity(string sentence) => sentence.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length + sentence.Count(char.IsPunctuation);
}

public class SyllableCounter : ISyllableCounter
{
    private static readonly Regex VowelRegex = new Regex("[аеёиоуыэюяАЕЁИОУЫЭЮЯ]", RegexOptions.Compiled);
    public Dictionary<int, int> CountSyllables(string text)
    {
        var result = new Dictionary<int, int>();
        foreach (var word in text.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries))
        {
            int count = VowelRegex.Matches(word).Count;
            if (count > 0) result[count] = result.ContainsKey(count) ? result[count] + 1 : 1;
        }
        return result;
    }
}

public class TextFormatter : ITextFormatter
{
    public List<string> FormatText(string text)
    {
        var lines = new List<string>();
        var words = text.Split(' ');
        var currentLine = string.Empty;

        foreach (var word in words)
        {
            if ((currentLine + word).Length > 50)
            {
                lines.Add(JustifyLine(currentLine.Trim()));
                currentLine = word + " ";
            }
            else currentLine += word + " ";
        }
        if (!string.IsNullOrWhiteSpace(currentLine)) lines.Add(JustifyLine(currentLine.Trim()));
        return lines;
    }

    private string JustifyLine(string line)
    {
        if (line.Length == 50) return line;
        int spacesToAdd = 50 - line.Length;
        var words = line.Split(' ').ToList();

        for (int i = 0; spacesToAdd > 0 && i < words.Count - 1; i++)
        {
            words[i] += " ";
            spacesToAdd--;
            if (i == words.Count - 2) i = -1;
        }
        return string.Join(' ', words);
    }
}

public class TextCompressor : ITextCompressor
{
    public (string compressedText, Dictionary<string, string> codeTable) CompressText(string text)
    {
        var bigramFrequency = new Dictionary<string, int>();
        for (int i = 0; i < text.Length - 1; i++)
        {
            string bigram = text.Substring(i, 2);
            bigramFrequency[bigram] = bigramFrequency.ContainsKey(bigram) ? bigramFrequency[bigram] + 1 : 1;
        }

        var sortedBigrams = bigramFrequency.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).Take(10).ToList();
        var codeTable = new Dictionary<string, string>();
        char code = 'Ā';

        foreach (var bigram in sortedBigrams) codeTable[bigram] = code++.ToString();

        string compressedText = text;
        foreach (var kvp in codeTable) compressedText = compressedText.Replace(kvp.Key, kvp.Value);

        return (compressedText, codeTable);
    }
}

public class TextDecoder : ITextDecoder
{
    public string DecompressText(string compressedText, Dictionary<string, string> codeTable)
    {
        var reverseCodeTable = codeTable.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        string decompressedText = compressedText;
        foreach (var kvp in reverseCodeTable) decompressedText = decompressedText.Replace(kvp.Key, kvp.Value);
        return decompressedText;
    }
}

// Абстрактный класс Задание
public abstract class Задание
{
    public string Название { get; private set; }
    protected Задание(string название) { Название = название; }
    public abstract void Выполнить();
    public override string ToString() => $"Название: {Название}";
}

// Классы-наследники Задание
public class Задание1 : Задание
{
    private readonly IEncryptionService _encryptionService;
    public Задание1(string название, IEncryptionService encryptionService) : base(название) { _encryptionService = encryptionService; }
    public override void Выполнить()
    {
        string originalMessage = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";
        string encryptedMessage = _encryptionService.Encrypt(originalMessage);
        string decryptedMessage = _encryptionService.Decrypt(encryptedMessage);

        Console.WriteLine($"Оригинальное сообщение: {originalMessage}");
        Console.WriteLine($"Зашифрованное сообщение: {encryptedMessage}");
        Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");
    }
}

public class Задание2 : Задание
{
    private readonly IComplexityCalculator _complexityCalculator;
    public Задание2(string название, IComplexityCalculator complexityCalculator) : base(название) { _complexityCalculator = complexityCalculator; }
    public override void Выполнить()
    {
        string sentence = "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе.";
        int complexity = _complexityCalculator.CalculateComplexity(sentence);

        Console.WriteLine($"Предложение: {sentence}");
        Console.WriteLine($"Сложность предложения: {complexity}");
    }
}

public class Задание3 : Задание
{
    private readonly ISyllableCounter _syllableCounter;
    public Задание3(string название, ISyllableCounter syllableCounter) : base(название) { _syllableCounter = syllableCounter; }
    public override void Выполнить()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";
        var syllableCounts = _syllableCounter.CountSyllables(text);

        Console.WriteLine($"Текст: {text}");
        Console.WriteLine("Количество слов по числу слогов:");
        foreach (var kvp in syllableCounts) Console.WriteLine($"{kvp.Key} слог(а): {kvp.Value} слово(а)");
    }
}

public class Задание4 : Задание
{
    private readonly ITextFormatter _textFormatter;
    public Задание4(string название, ITextFormatter textFormatter) : base(название) { _textFormatter = textFormatter; }
    public override void Выполнить()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";
        var formattedLines = _textFormatter.FormatText(text);

        Console.WriteLine($"Оригинальный текст: {text}");
        Console.WriteLine("Отформатированный текст:");
        foreach (var line in formattedLines) Console.WriteLine(line);
    }
}

public class Задание5 : Задание
{
    private readonly ITextCompressor _textCompressor;
    public Задание5(string название, ITextCompressor textCompressor) : base(название) { _textCompressor = textCompressor; }
    public override void Выполнить()
    {
        string text = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        var (compressedText, codeTable) = _textCompressor.CompressText(text);

        Console.WriteLine($"Оригинальный текст: {text}");
        Console.WriteLine($"Сжатый текст: {compressedText}");
        Console.WriteLine("Таблица кодов:");
        foreach (var kvp in codeTable) Console.WriteLine($"{kvp.Key} => {kvp.Value}");
    }
}

public class Задание6 : Задание
{
    private readonly ITextDecoder _textDecoder;
    private readonly Dictionary<string, string> _codeTable;
    private readonly string _compressedText;

    public Задание6(string название, ITextDecoder textDecoder, Dictionary<string, string> codeTable, string compressedText)
        : base(название)
    {
        _textDecoder = textDecoder;
        _codeTable = codeTable;
        _compressedText = compressedText;
    }

    public override void Выполнить()
    {
        string decompressedText = _textDecoder.DecompressText(_compressedText, _codeTable);

        Console.WriteLine($"Сжатый текст: {_compressedText}");
        Console.WriteLine($"Расшифрованный текст: {decompressedText}");
    }
}

// Пример использования
public class Program
{
    public static void Main(string[] args)
    {
        IEncryptionService encryptionService = new ReverseWordEncryptionService();
        IComplexityCalculator complexityCalculator = new SentenceComplexityCalculator();
        ISyllableCounter syllableCounter = new SyllableCounter();
        ITextFormatter textFormatter = new TextFormatter();
        ITextCompressor textCompressor = new TextCompressor();
        ITextDecoder textDecoder = new TextDecoder();

        string textToCompress = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        var (compressedText, codeTable) = textCompressor.CompressText(textToCompress);

        Задание[] задания = new Задание[]
        {
            new Задание1("Задание 1", encryptionService),
            new Задание2("Задание 2", complexityCalculator),
            new Задание3("Задание 3", syllableCounter),
            new Задание4("Задание 4", textFormatter),
            new Задание5("Задание 5", textCompressor),
            new Задание6("Задание 6", textDecoder, codeTable, compressedText)
        };

        foreach (var задание in задания)
        {
            Console.WriteLine(задание);
            задание.Выполнить();
            Console.WriteLine();
        }
    }
}
