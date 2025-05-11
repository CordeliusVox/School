using System;
using System.Collections.Generic;
using System.Linq;

// Made by Ariel Guvkin

class TicTacToe
{
    static void Main() {
        // Prompt the user to define the board size (3 - 9).
        int Rows = GetBoardSize("Rows");
        int Columns = GetBoardSize("Columns");

        // Gamemode.
        bool IsPlayerVsComputer = ChooseGameMode();

        // Track game statistics to display wins and draws at the end.
        int Player1Wins = 0;
        int OpponentWins = 0;
        int Draws = 0;

        // Control whether to start a new game after one ends.
        bool PlayAgain = true;

        // Main loop to handle multiple games until user chooses to stop.
        while (PlayAgain)
        {
            // Create a new game board as a 2D array and fill it with empty spaces.
            char[,] Board = new char[Rows, Columns];
            InitializeBoard(Board);

            // Store prev moves in stacks
            Stack<int> PlayerXMoves = new Stack<int>(); // Moves made by 'X'.
            Stack<int> PlayerOMoves = new Stack<int>(); // Moves made by 'O' in player vs player.

            // Set 'X' as the starting player (Can Change).
            char CurrentPlayer = 'X';

            // determine when the current game ends.
            bool GameEnded = false;

            // Inner game loop that runs until a win or draw happens.
            while (!GameEnded)
            {
                // Clear the console to provide a clean display for each turn.
                Console.Clear();

                // Show the current state of the board with numbers or symbols.
                DisplayBoard(Board, Rows, Columns);

                if (CurrentPlayer == 'X')
                {
                    // Player 'X' makes a move
                    int Move = GetPlayerMove(Board, Rows, Columns, 'X', PlayerXMoves);
                    PlaceMove(Board, Move, 'X', Columns);
                    PlayerXMoves.Push(Move); // Record move for an undo.
                }
                else if (IsPlayerVsComputer)
                {
                    // Computer (AI) makes a move as 'O'.
                    Console.WriteLine("Computer is thinking...");
                    int Move = GetComputerMove(Board, Rows, Columns);
                    PlaceMove(Board, Move, 'O', Columns);
                }
                else
                {
                    // Player 'O' makes a move in player vs player.
                    int Move = GetPlayerMove(Board, Rows, Columns, 'O', PlayerOMoves);
                    PlaceMove(Board, Move, 'O', Columns);
                    PlayerOMoves.Push(Move); // Record move for an undo.
                }

                // Check if the current player has won after their move.
                if (HasWon(Board, CurrentPlayer, Rows, Columns))
                {
                    Console.Clear();
                    DisplayBoard(Board, Rows, Columns);
                    Console.WriteLine($"{CurrentPlayer} wins!");
                    if (CurrentPlayer == 'X') Player1Wins++;
                    else OpponentWins++;
                    GameEnded = true;
                }
                // Check if the game ends in a draw
                else if (IsDraw(Board, Rows, Columns))
                {
                    Console.Clear();
                    DisplayBoard(Board, Rows, Columns);
                    Console.WriteLine("It's a draw!");
                    Draws++;
                    GameEnded = true;
                }
                else
                {
                    // Switch to the other player if no win or draw
                    CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
                }
            }

            // After game ends, ask if the user wants to play again
            while (true)
            {
                Console.Write("Do you want to play again? (y/n): ");
                string Response = Console.ReadLine().ToLower();
                if (Response == "y")
                {
                    PlayAgain = true;
                    break;
                }
                else if (Response == "n")
                {
                    PlayAgain = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                    Console.ResetColor();
                }
            }
        }

        // Display final stats based on game mode
        if (IsPlayerVsComputer)
            Console.WriteLine($"Wins: {Player1Wins}, Losses: {OpponentWins}, Draws: {Draws}");
        else
            Console.WriteLine($"Player1 Wins: {Player1Wins}, Player2 Wins: {OpponentWins}, Draws: {Draws}");
    }

    static bool ChooseGameMode() // Let the user choose between player vs ai or player vs player
    {
        while (true)
        {
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1. Player vs. Computer");
            Console.WriteLine("2. Player vs. Player");
            Console.Write("Enter your choice (1 or 2): ");
            string Input = Console.ReadLine();
            if (int.TryParse(Input, out int choice) && (choice == 1 || choice == 2))
            {
                return choice == 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                Console.ResetColor();
            }
        }
    }

    static int GetBoardSize(string Dimension) // Get board size from user
    {
        int Size;
        while (true)
        {
            Console.Write($"Enter number of {Dimension} (3-9): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out Size) && Size >= 3 && Size <= 9)
            {
                return Size;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number between 3 and 9.");
                Console.ResetColor();
            }
        }
    }

    static void InitializeBoard(char[,] Board) // Set up the board by filling all cells with spaces
    {
        for (int i = 0; i < Board.GetLength(0); i++)
            for (int j = 0; j < Board.GetLength(1); j++)
                Board[i, j] = ' ';
    }

    static void DisplayBoard(char[,] Board, int Rows, int Columns) // Display the game board, with 'X' in red and 'O' in blue
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                int cell = i * Columns + j + 1;  // Calculate the cell number by using the eq: cell number = row * columns + column + 1
                if (Board[i, j] == ' ')
                {
                    Console.Write(cell.ToString().PadLeft(2));  // Print the cell number, ensuring it is right aligned with padding if necessary
                }
                else if (Board[i, j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X");
                    Console.ResetColor();
                }
                else if (Board[i, j] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" O");
                    Console.ResetColor();
                }
                if (j < Columns - 1) Console.Write("|");
            }
            Console.WriteLine();
            if (i < Rows - 1) Console.WriteLine(new string('-', Columns * 3 - 1));
        }
    }

    static int GetPlayerMove(char[,] Board, int Rows, int Columns, char Player, Stack<int> Moves) // Handle player input
    {
        while (true)
        {
            Console.Write($"Player {Player}, enter your move (0 to undo): ");
            string InputStr = Console.ReadLine();
            if (int.TryParse(InputStr, out int Input))
            {
                if (Input == 0)
                {
                    if (Moves.Count > 0)
                    {
                        int PrevMove = Moves.Pop();
                        PlaceMove(Board, PrevMove, ' ', Columns);
                        Console.Clear();
                        DisplayBoard(Board, Rows, Columns);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No moves to undo.");
                        Console.ResetColor();
                    }
                }
                else if (Input > 0 && Input <= Rows * Columns)
                {
                    if (IsValidMove(Board, Input, Rows, Columns))
                    {
                        return Input;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cell already occupied.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Move out of range.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ResetColor();
            }
        }
    }

    static bool IsValidMove(char[,] Board, int Move, int Rows, int Columns) // Verify if a move is valid (if cell is empty and borders)
    {
        if (Move < 1 || Move > Rows * Columns) return false;
        int row = (Move - 1) / Columns;
        int col = (Move - 1) % Columns;

        return Board[row, col] == ' ';
    }

    static void PlaceMove(char[,] Board, int Move, char Symbol, int Columns) // Place a player's symbol at the specified position on the board (that he chose)
    {
        int row = (Move - 1) / Columns;
        int col = (Move - 1) % Columns;
        Board[row, col] = Symbol;
    }

    static bool HasWon(char[,] Board, char Player, int Rows, int Columns) //  Checks if player has won by checkin rows, columns, and dig
    {
        for (int i = 0; i < Rows; i++) // Check each row to see if all cells in that row are filled by the player
        {
            // Use Enumerable.Range(0, columns) to create a range from 0 to columns - 1,
            // then check if all elements in the row (board[i, j]) are equal to the player.
            if (Enumerable.Range(0, Columns).All(j => Board[i, j] == Player))
                return true;  // If all cells in the row match the player, return true (player has won).
        }

        for (int j = 0; j < Columns; j++) // Check each column to see if all cells in that column are filled by the player
        {
            // Use Enumerable.Range(0, rows) to create a range from 0 to rows - 1,
            // then check if all elements in the column (board[i, j]) are equal to the player.
            if (Enumerable.Range(0, Rows).All(i => Board[i, j] == Player))
                return true;  // If all cells in the column match the player, return true (player has won).
        }

        if (Rows == Columns) // Check diagonals only if the board is square (rows == columns)
        {
            if (Enumerable.Range(0, Rows).All(i => Board[i, i] == Player)) // Check the top left to bottom right diagonal
                return true;  // If all cells in the top left to bottom right diagonal match the player, return true (player has won).

            if (Enumerable.Range(0, Rows).All(i => Board[i, Columns - 1 - i] == Player)) // Check the top-right to bottom-left diagonal
                return true;  // If all cells in the top right to bottom left diagonal match the player, return true (player has won).
        }

        // If no winning condition is found, return false (the player has not won).
        return false;
    }

    static bool IsDraw(char[,] Board, int Rows, int Columns) // Check if the game is a draw (board full or no win possible)
    {
        return IsBoardFull(Board, Rows, Columns) || IsEarlyDraw(Board, Rows, Columns);
    }

    static bool IsBoardFull(char[,] Board, int Rows, int Columns) // Check if the board has no empty spaces left
    {
        return !Enumerable.Range(0, Rows).Any(i => Enumerable.Range(0, Columns).Any(j => Board[i, j] == ' '));
    }

    static bool IsEarlyDraw(char[,] Board, int Rows, int Columns) // Detect an early draw where no player can win, even if board isnt full
    {
        for (int i = 0; i < Rows; i++)
            if (!RowHasBoth(Board, i, Columns)) return false;
        for (int j = 0; j < Columns; j++)
            if (!ColumnHasBoth(Board, j, Rows)) return false;
        if (Rows == Columns)
        {
            if (!DiagonalHasBoth(Board, Rows, true) || !DiagonalHasBoth(Board, Rows, false))
                return false;
        }
        return true;
    }

    static bool RowHasBoth(char[,] Board, int Row, int Columns) // Helper function, check if a row contains both 'X' and 'O'
    {
        bool HasX = false, HasO = false;
        for (int j = 0; j < Columns; j++)
        {
            if (Board[Row, j] == 'X') HasX = true;
            else if (Board[Row, j] == 'O') HasO = true;
        }
        return HasX && HasO;
    }

    static bool ColumnHasBoth(char[,] Board, int Columns, int Rows) // Helper fucntion, check if a column contains both 'X' and 'O'
    {
        bool HasX = false, HasO = false;
        for (int i = 0; i < Rows; i++)
        {
            if (Board[i, Columns] == 'X') HasX = true;
            else if (Board[i, Columns] == 'O') HasO = true;
        }
        return HasX && HasO;
    }

    static bool DiagonalHasBoth(char[,] Board, int Size, bool IsMain) // Helper function Check if a diagonal contains both 'X' and 'O'
    {
        bool HasX = false, HasO = false;
        for (int i = 0; i < Size; i++)
        {
            char cell = IsMain ? Board[i, i] : Board[i, Size - 1 - i];
            if (cell == 'X') HasX = true;
            else if (cell == 'O') HasO = true;
        }
        return HasX && HasO;
    }

    static int GetComputerMove(char[,] Board, int Rows, int Columns) // Determine the computer's best move using MiniMax algo
    {
        int BestScore = int.MinValue;
        int BestMove = -1;
        for (int n = 1; n <= Rows * Columns; n++)
        {
            if (IsValidMove(Board, n, Rows, Columns))
            {
                PlaceMove(Board, n, 'O', Columns);
                int score = MiniMax(Board, 0, false, int.MinValue, int.MaxValue, Rows, Columns);
                PlaceMove(Board, n, ' ', Columns);
                if (score > BestScore)
                {
                    BestScore = score;
                    BestMove = n;
                }
            }
        }
        return BestMove;
    }

    static int MiniMax(char[,] Board, int Depth, bool IsMaximizing, int Alpha, int Beta, int Rows, int Columns) // MiniMax algorithm with "alpha beta pruning" for optimal AI play
    {
        if (HasWon(Board, 'O', Rows, Columns)) return 10 - Depth;
        if (HasWon(Board, 'X', Rows, Columns)) return Depth - 10;
        if (IsDraw(Board, Rows, Columns)) return 0;

        if (IsMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Board[i, j] == ' ')
                    {
                        Board[i, j] = 'O';
                        int score = MiniMax(Board, Depth + 1, false, Alpha, Beta, Rows, Columns);
                        Board[i, j] = ' ';
                        bestScore = Math.Max(bestScore, score);
                        Alpha = Math.Max(Alpha, score);
                        if (Beta <= Alpha) break;
                    }
                }
                if (Beta <= Alpha) break;
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Board[i, j] == ' ')
                    {
                        Board[i, j] = 'X';
                        int score = MiniMax(Board, Depth + 1, true, Alpha, Beta, Rows, Columns);
                        Board[i, j] = ' ';
                        bestScore = Math.Min(bestScore, score);
                        Beta = Math.Min(Beta, score);
                        if (Beta <= Alpha) break;
                    }
                }
                if (Beta <= Alpha) break;
            }
            return bestScore;
        }
    }
}
