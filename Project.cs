using System;
using System.Threading;

// Hello teacher, just for a little note. I did this in 2 days so it might not be the best. I have used strings for a couple of actions in here,
// But I promise you I could make it with numbers. Theres a 5 second delay between each action to ensure readability. (You could change this in the threads sleeps.)

namespace Project_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point of the program
            RunProgram();
        }

        static void RunProgram() // Main loop that runs the program. Handles menu display, user input, and program flow.
        {
            int errors = 0; // Keeps track of invalid menu attempts
            int input; // Stores user menu selection

            do
            {
                Console.Clear(); // Clear the console for better readability
                input = DisplayMenu(); // Display the menu and get user input
                ProcessMenuChoice(ref errors, input); // Process the user's menu choice
            } while (errors < 3 && input != 1); // Exit if too many errors or user chooses to exit

            // Display appropriate exit message
            if (errors == 3)
            {
                DisplayMessage("Too many invalid attempts. Exiting the program.", ConsoleColor.Red);
            }
            else
            {
                DisplayMessage("Exiting the program. Goodbye!", ConsoleColor.Green);
            }
        }

        static int DisplayMenu() // Displays the main menu to the user and prompts for input. -> Returns user's menu choice as an integer.
        {
            DisplayMessage("\n===== Main Menu =====", ConsoleColor.Cyan);
            Console.WriteLine("1. End the program");
            Console.WriteLine("2. Reverse numbers");
            Console.WriteLine("3. Amicable numbers");
            Console.WriteLine("4. Special numbers");
            Console.WriteLine("5. Rectangle");
            DisplayMessage("Please enter your choice: ", ConsoleColor.Yellow);

            return ParseIntInput(); // Parse and return the user's input
        }

        static void ProcessMenuChoice(ref int Errors, int Choice) // Processes the user's menu choice and directs to the appropriate action.
        {
            Console.Clear(); // Clear the console before performing an action
            switch (Choice)
            {
                case 1: // Exit the program
                    break;
                case 2: // Reverse numbers
                    ReverseNumbers();
                    break;
                case 3: // Find amicable numbers
                    AmicableNumbers();
                    break;
                case 4: // Find special numbers
                    SpecialNumbers();
                    break;
                case 5: // Draw a rectangle
                    DrawRectangle();
                    break;
                default:
                    Errors++; // Increment error count for invalid choice
                    DisplayMessage($"Invalid choice! You have {3 - Errors} attempts left.", ConsoleColor.Red);
                    Thread.Sleep(2000); // Pause to let the user read the error message
                    break;
            }
        }

        static void DisplayMessage(string Message, ConsoleColor Color) // Displays a message in a specific color.
        {
            Console.ForegroundColor = Color; // Set text color
            Console.WriteLine(Message); // Print the message
            Console.ResetColor(); // Reset to default console color
        }

        static int ParseIntInput() // Parses user input as an int, ensuring it is valid. -> Returns valid integer input from the user.
        {
            while (true)
            {
                string Input = Console.ReadLine(); // Read user input
                if (int.TryParse(Input, out int result)) // Check if input is a valid integer
                {
                    return result; // Return the valid integer
                }
                DisplayMessage("Invalid input. Please enter a valid number:", ConsoleColor.Red);
            }
        }

        static void ReverseNumbers() // Handles both the regular way and table way
        {
            DisplayMessage("You chose to reverse numbers!", ConsoleColor.Cyan);

            // Ask the player how they want to process the reversal
            DisplayMessage("\nChoose how you want to reverse numbers:", ConsoleColor.Cyan);
            DisplayMessage("1. Regular way (Single number)", ConsoleColor.Yellow);
            DisplayMessage("2. Table way (10 numbers)", ConsoleColor.Yellow);

            int Choice = GetValidInput(1, 2); // Ensure valid input

            if (Choice == 1)
            {
                // Regular way: Reverse a single number with a group size
                DisplayMessage("Enter the number to reverse: ", ConsoleColor.Yellow);
                int Number = ParseIntInput();

                DisplayMessage("Enter the group size for reversal: ", ConsoleColor.Yellow);
                int GroupSize = ParseIntInput();

                if (GroupSize <= 0)
                {
                    DisplayMessage("Group size must be greater than 0!", ConsoleColor.Red);
                    return;
                }

                string Reversed = ReverseByParts(Number, GroupSize);
                DisplayMessage($"Reversed number: {Reversed}", ConsoleColor.Green);
            }
            else if (Choice == 2)
            {
                // Table way: Handle 10 numbers and display them in a table
                HandleTableWay();
            }

            Thread.Sleep(5000); // Pause to let the user see the result
        }

        static void HandleTableWay() // Prints out the table form of reverse numbers (Gets 10 numbers from the user)
        {
            const int NumberCount = 10;
            int[] Numbers = new int[NumberCount];
            string[,] ReversedTable = new string[NumberCount, 3]; // Rows: 10 numbers, Columns: groups 2, 3, 4

            DisplayMessage("\nEnter 10 numbers to reverse:", ConsoleColor.Cyan);

            // Collect 10 numbers from the user
            for (int i = 0; i < NumberCount; i++)
            {
                DisplayMessage($"Enter number {i + 1}: ", ConsoleColor.Yellow);
                Numbers[i] = ParseIntInput();
            }

            // Reverse each number for groups of 2, 3, and 4
            for (int i = 0; i < NumberCount; i++)
            {
                ReversedTable[i, 0] = ReverseByParts(Numbers[i], 2); // Group of 2
                ReversedTable[i, 1] = ReverseByParts(Numbers[i], 3); // Group of 3
                ReversedTable[i, 2] = ReverseByParts(Numbers[i], 4); // Group of 4
            }

            // Display the table
            DisplayMessage("\nReversed numbers table:", ConsoleColor.Cyan);
            Console.WriteLine("Original\tGroup 2\t\tGroup 3\t\tGroup 4");
            Console.WriteLine("--------\t--------\t--------\t--------");

            for (int i = 0; i < NumberCount; i++)
            {
                Console.WriteLine($"{Numbers[i]}\t\t{ReversedTable[i, 0]}\t\t{ReversedTable[i, 1]}\t\t{ReversedTable[i, 2]}");
            }
        }

            static string ReverseByParts(int number, int groupSize)
        {
            string NumberString = number.ToString();
            char[] Reversed = new char[NumberString.Length];

            // Reverse the number in groups
            for (int i = 0; i < NumberString.Length; i += groupSize)
            {
                int End = Math.Min(i + groupSize, NumberString.Length); // Ensure we don't exceed the length
                string Group = NumberString.Substring(i, End - i); // Get the current group
                char[] GroupArray = Group.ToCharArray();

                Array.Reverse(GroupArray); // Reverse the group
                GroupArray.CopyTo(Reversed, i); // Copy the reversed group
            }

            return new string(Reversed).TrimEnd('\0'); // Convert char array to string
        }

            static void AmicableNumbers() // Finds and displays amicable pairs near a given number.
        {
            DisplayMessage("Enter a number between 3 and 10,000: ", ConsoleColor.Yellow);
            int Number = ParseIntInput();

            if (Number < 3 || Number > 10000)
            {
                DisplayMessage("Invalid input. Please enter a number in the range of 3 - 10,000.", ConsoleColor.Red);
                return;
            }

            DisplayMessage("The 4 closest amicable pairs above the number are: ", ConsoleColor.Cyan);
            FindAmicablePairs(Number, 4); // Find and display amicable pairs
            Thread.Sleep(5000); // Pause for user to read results
        }

        static void FindAmicablePairs(int start, int count) // Finds and prints a specified number of amicable pairs starting from a given number.
        {
            int PairsFound = 0; // Tracks the number of pairs found
            int CurrentNumber = start + 1; // Start search from the next number

            while (PairsFound < count)
            {
                int Sum1 = SumOfDivisors(CurrentNumber);

                if (Sum1 > CurrentNumber) // Avoid duplicates by ensuring sum1 > currentNumber
                {
                    int Sum2 = SumOfDivisors(Sum1);

                    if (Sum2 == CurrentNumber && Sum1 != CurrentNumber)
                    {
                        DisplayMessage($"({CurrentNumber}, {Sum1})", ConsoleColor.Green);
                        PairsFound++; // Increment count of pairs found
                    }
                }
                CurrentNumber++; // Check the next number
            }

            if (PairsFound == 0)
            {
                DisplayMessage("No amicable pairs found.", ConsoleColor.Red);
            }
        }

        static int SumOfDivisors(int Number) // Computes the sum of divisors of a number. -> Returns sum of divisors
        {
            int Sum = 1; // 1 is a divisor for all numbers

            for (int i = 2; i <= Math.Sqrt(Number); i++)
            {
                if (Number % i == 0) // Check if 'i' is a divisor
                {
                    Sum += i;

                    if (i != Number / i) // Add the complementary divisor
                    {
                        Sum += Number / i;
                    }
                }
            }

            return Sum; // Return the sum of divisors
        }

        static void SpecialNumbers() // Finds the closest prime numbers, Germain primes, and palindromes to the given number.
        {
            DisplayMessage("Enter a number between 7 and 8000: ", ConsoleColor.Yellow);
            int Number = GetValidInput(7, 8000); // Ensure the number is valid within the given range

            Console.Clear();
            DisplayMessage("\nFinding closest numbers...\n", ConsoleColor.Cyan);

            // Variables to store the results
            int LowerPrime = -1, UpperPrime = -1;
            int LowerGermain = -1, UpperGermain = -1;
            int LowerPalindrome = -1, UpperPalindrome = -1;

            // Iterate to find the closest numbers for each condition
            for (int i = 0; LowerPrime == -1 || UpperPrime == -1 || LowerGermain == -1 || UpperGermain == -1 || LowerPalindrome == -1 || UpperPalindrome == -1; i++)
            {
                // Check for primes
                if (LowerPrime == -1 && IsPrime(Number - i)) LowerPrime = Number - i;
                if (UpperPrime == -1 && IsPrime(Number + i)) UpperPrime = Number + i;

                // Check for Germain primes
                if (LowerGermain == -1 && IsPrime(Number - i) && IsPrime(2 * (Number - i) + 1)) LowerGermain = Number - i;
                if (UpperGermain == -1 && IsPrime(Number + i) && IsPrime(2 * (Number + i) + 1)) UpperGermain = Number + i;

                // Check for palindromes
                if (LowerPalindrome == -1 && IsPalindrome(Number - i)) LowerPalindrome = Number - i;
                if (UpperPalindrome == -1 && IsPalindrome(Number + i)) UpperPalindrome = Number + i;
            }

            // Display results
            DisplayMessage($"1) Closest prime numbers: Lower = {LowerPrime}, Upper = {UpperPrime}", ConsoleColor.Green);
            DisplayMessage($"2) Closest Germain primes: Lower = {LowerGermain}, Upper = {UpperGermain}", ConsoleColor.Green);
            DisplayMessage($"3) Closest palindromes: Lower = {LowerPalindrome}, Upper = {UpperPalindrome}\n", ConsoleColor.Green);

            Thread.Sleep(5000); // Small delay for user readability
        }

        static bool IsPrime(int Number) // Checks if a number is a prime. -> Returns True if the number is prime. Otherwise, false.
        {
            if (Number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(Number); i++)
            {
                if (Number % i == 0)
                    return false;
            }
            return true;
        }

        static bool IsPalindrome(int Number) // Checks if a number is a palindrome. -> Returns True if the number is a palindrome. Otherwise, false.
        {
            // I know I used a cheeky way using strings :(
            string String = Number.ToString();
            for (int i = 0, j = String.Length - 1; i < j; i++, j--)
            {
                if (String[i] != String[j])
                    return false;
            }
            return true;
        }

        static void DrawRectangle() // Draws a rectangle with specific height and width.
        {
            // Request and validate dimensions for the rectangle
            DisplayMessage("Enter an odd height (5 to 79): ", ConsoleColor.Yellow);
            int Height = GetValidOddInput(5, 79); // Validate odd height

            DisplayMessage("Enter an odd width (5 to 79): ", ConsoleColor.Yellow);
            int Width = GetValidOddInput(5, 79); // Validate odd width

            // Determine frame thickness for the rectangle
            int FrameThicknessX = GetFrameThickness(Width);
            int FrameThicknessY = GetFrameThickness(Height);

            Console.Clear();
            DisplayMessage("\nYour rectangle:\n", ConsoleColor.Cyan);

            // Loop through rows and columns to draw the rectangle
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    // Check if the current position is within the frame area
                    if (i < FrameThicknessY || i >= Height - FrameThicknessY || j < FrameThicknessX || j >= Width - FrameThicknessX)
                    {
                        Console.Write("F"); // Frame character
                    }
                    else
                    {
                        // Calculate the fill values (1-9) based on a 3x3 pattern
                        int value = ((i - FrameThicknessY) % 3) * 3 + ((j - FrameThicknessX) % 3) + 1;
                        Console.Write(value);
                    }
                }
                Console.WriteLine(); // Move to the next line after each row
            }

            Thread.Sleep(5000); // Pause to let the user review the rectangle
        }

        static int GetValidOddInput(int Min, int Max) // Validates an odd input within a specified range. -> Returns an odd integer within the range.
        {
            while (true)
            {
                int Input = ParseIntInput(); // Parse the input
                if (Input >= Min && Input <= Max && Input % 2 != 0) // Validate the range and oddness
                    return Input;

                DisplayMessage($"Invalid input. Enter an odd number between {Min} and {Max}:", ConsoleColor.Red);
            }
        }

        static int GetFrameThickness(int Dimension) // Determines the thickness of the frame that satisfies the rules. -> Returns the valid frame thickness.
        {
            for (int thickness = 3; thickness >= 1; thickness--) // Try maximum thickness of 3
            {
                int InnerDimension = Dimension - 2 * thickness;

                // Ensure the inner area is divisible by 3
                if (InnerDimension > 0 && InnerDimension % 3 == 0)
                    return thickness;
            }
            return 1; // Default to minimum thickness
        }

        static int GetValidInput(int Min, int Max) // Validates input within a specific range. -> Returns an number input within the range.
        {
            while (true)
            {
                int input = ParseIntInput(); // Parse user input as an int
                if (input >= Min && input <= Max) // Check if the input is within range
                    return input;

                // Display an error message if input is invalid
                DisplayMessage($"Invalid input. Enter a number between {Min} and {Max}: ", ConsoleColor.Red);
            }
        }
    }
}