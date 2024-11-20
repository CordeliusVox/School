using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Matrix Digital Rain";
        Console.CursorVisible = false; // Hide the cursor for aesthetics
        Console.ForegroundColor = ConsoleColor.Green;

        // Set the console dimensions to maximize the effect
        Console.WindowHeight = Console.LargestWindowHeight - 2;
        Console.WindowWidth = Console.LargestWindowWidth - 2;

        MatrixRain();

        // End message
        Console.ResetColor();
        Console.WriteLine("\nSimulation complete. Press any key to exit...");
        Console.ReadKey();
    }

    static void MatrixRain()
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        // Initialize columns
        int[] columnHeights = new int[width];
        Random random = new Random();

        for (int i = 0; i < width; i++)
        {
            columnHeights[i] = random.Next(0, height);
        }

        while (!Console.KeyAvailable) // Run until a key is pressed
        {
            for (int x = 0; x < width; x++)
            {
                // Randomly decide to drop a character in each column
                if (random.Next(0, 10) < 3) 
                {
                    int y = columnHeights[x];
                    Console.SetCursorPosition(x, y);
                    Console.Write(GetRandomCharacter());
                    columnHeights[x] = (y + 1) % height; // Wrap around to the top
                }
            }

            Thread.Sleep(50); // Control the animation speed
        }
    }

    static char GetRandomCharacter()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#$%&*";
        Random random = new Random();
        return chars[random.Next(chars.Length)];
    }
}