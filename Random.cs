using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Cool Console App";
        Console.ForegroundColor = ConsoleColor.Cyan;

        DisplayBanner("Welcome to the Cool Console App");

        // Simulate a cool loading bar
        Console.WriteLine("\nLoading, please wait...\n");
        LoadingBar();

        // Display a random inspirational quote
        Console.WriteLine("\nHere's a quote to brighten your day:\n");
        DisplayRandomQuote();

        // Closing message
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DisplayBanner(string message)
    {
        string border = new string('*', message.Length + 6);
        Console.WriteLine(border);
        Console.WriteLine($"*  {message}  *");
        Console.WriteLine(border);
    }

    static void LoadingBar()
    {
        const int barLength = 30;
        const int delay = 100; // milliseconds

        for (int i = 0; i <= barLength; i++)
        {
            Console.Write("\r[");
            Console.Write(new string('#', i));
            Console.Write(new string('.', barLength - i));
            Console.Write($"] {i * 100 / barLength}%");
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    static void DisplayRandomQuote()
    {
        string[] quotes = {
            "The best way to predict the future is to invent it.",
            "Do not wait to strike till the iron is hot, but make it hot by striking.",
            "Success is not the key to happiness. Happiness is the key to success.",
            "In the middle of every difficulty lies opportunity.",
            "What you get by achieving your goals is not as important as what you become by achieving your goals."
        };

        Random random = new Random();
        string randomQuote = quotes[random.Next(quotes.Length)];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\"{randomQuote}\"");
        Console.ResetColor();
    }
}