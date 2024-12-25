using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();

            // Get current time
            DateTime now = DateTime.Now;

            // Draw the clock
            DrawBigClock(now);

            Thread.Sleep(1000); // Update every second
        }
    }

    static void DrawBigClock(DateTime time)
    {
        string hour = time.Hour.ToString("D2");
        string minute = time.Minute.ToString("D2");
        string second = time.Second.ToString("D2");
        string currentTime = $"{hour}:{minute}:{second}";

        // Define the ASCII art representation for numbers
        string[][] bigNumbers = GetBigNumbers();

        int startX = Console.WindowWidth / 2 - (currentTime.Length * 8 / 2);
        int startY = Console.WindowHeight / 2 - 3;

        // Print each character as big text
        for (int i = 0; i < currentTime.Length; i++)
        {
            char c = currentTime[i];
            int index = c == ':' ? 10 : c - '0'; // Handle ':' as the 10th index
            DrawBigCharacter(bigNumbers[index], startX + (i * 8), startY);
        }
    }

    static void DrawBigCharacter(string[] bigChar, int startX, int startY)
    {
        Random random = new Random();
        ConsoleColor color = (ConsoleColor)random.Next(1, 16);

        for (int y = 0; y < bigChar.Length; y++)
        {
            Console.SetCursorPosition(startX, startY + y);
            Console.ForegroundColor = color;
            Console.Write(bigChar[y]);
        }

        Console.ResetColor();
    }

    static string[][] GetBigNumbers()
    {
        return new string[][]
        {
            new string[] // 0
            {
                " ██████ ",
                "██    ██",
                "██    ██",
                "██    ██",
                " ██████ "
            },
            new string[] // 1
            {
                "   ██   ",
                "  ███   ",
                "   ██   ",
                "   ██   ",
                " ██████ "
            },
            new string[] // 2
            {
                " ██████ ",
                "      ██",
                " ██████ ",
                "██      ",
                "████████"
            },
            new string[] // 3
            {
                " ██████ ",
                "      ██",
                " ██████ ",
                "      ██",
                " ██████ "
            },
            new string[] // 4
            {
                "██    ██",
                "██    ██",
                "████████",
                "      ██",
                "      ██"
            },
            new string[] // 5
            {
                "████████",
                "██      ",
                "████████",
                "      ██",
                " ██████ "
            },
            new string[] // 6
            {
                " ██████ ",
                "██      ",
                "████████",
                "██    ██",
                " ██████ "
            },
            new string[] // 7
            {
                "████████",
                "     ██ ",
                "    ██  ",
                "   ██   ",
                "  ██    "
            },
            new string[] // 8
            {
                " ██████ ",
                "██    ██",
                " ██████ ",
                "██    ██",
                " ██████ "
            },
            new string[] // 9
            {
                " ██████ ",
                "██    ██",
                " ██████ ",
                "      ██",
                " ██████ "
            },
            new string[] // Colon (:)
            {
                "        ",
                "   ██   ",
                "        ",
                "   ██   ",
                "        "
            }
        };
    }
}