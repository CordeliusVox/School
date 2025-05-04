using System;
using System.Collections.Generic;

class TicTacToe
{
    static void Main()
    {
        // Get board dimensions from user
        int rows = GetBoardSize("rows");
        int columns = GetBoardSize("columns");

        // Let user choose game mode
        bool isPlayerVsComputer = ChooseGameMode();

        // Initialize game statistics
        int player1Wins = 0;
        int opponentWins = 0;
        int draws = 0;

        bool playAgain = true;
        while (playAgain)
        {
            // Initialize new game
            char[,] board = new char[rows, columns];
            InitializeBoard(board);
            Stack<int> playerXMoves = new Stack<int>(); // Moves for 'X' player
            Stack<int> playerOMoves = new Stack<int>(); // Moves for 'O' player in PvP mode
            char currentPlayer = 'X'; // 'X' starts first
            bool gameEnded = false;

            while (!gameEnded)
            {
                Console.Clear();
                DisplayBoard(board, rows, columns);

                if (currentPlayer == 'X')
                {
                    // Handle Player 'X' move
                    int move = GetPlayerMove(board, rows, columns, 'X', playerXMoves);
                    PlaceMove(board, move, 'X', columns);
                    playerXMoves.Push(move);
                }
                else if (isPlayerVsComputer)
                {
                    // Handle computer move with advanced AI
                    Console.WriteLine("Computer is thinking...");
                    int move = GetComputerMove(board, rows, columns);
                    PlaceMove(board, move, 'O', columns);
                }
                else
                {
                    // Handle Player 'O' move in PvP mode
                    int move = GetPlayerMove(board, rows, columns, 'O', playerOMoves);
                    PlaceMove(board, move, 'O', columns);
                    playerOMoves.Push(move);
                }

                // Check game status
                if (HasWon(board, currentPlayer, rows, columns))
                {
                    Console.Clear();
                    DisplayBoard(board, rows, columns);
                    Console.WriteLine($"{currentPlayer} wins!");
                    if (currentPlayer == 'X') player1Wins++;
                    else opponentWins++;
                    gameEnded = true;
                }
                else if (IsDraw(board, rows, columns))
                {
                    Console.Clear();
                    DisplayBoard(board, rows, columns);
                    Console.WriteLine("It's a draw!");
                    draws++;
                    gameEnded = true;
                }
                else
                {
                    // Switch players
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }

            // Prompt for another game
            Console.Write("Do you want to play again? (y/n): ");
            playAgain = Console.ReadLine().ToLower() == "y";
        }

        // Display final statistics
        if (isPlayerVsComputer)
            Console.WriteLine($"Wins: {player1Wins}, Losses: {opponentWins}, Draws: {draws}");
        else
            Console.WriteLine($"Player1 Wins: {player1Wins}, Player2 Wins: {opponentWins}, Draws: {draws}");
    }

    // Prompt user to choose game mode
    static bool ChooseGameMode()
    {
        Console.WriteLine("Choose game mode:");
        Console.WriteLine("1. Player vs. Computer");
        Console.WriteLine("2. Player vs. Player");
        Console.Write("Enter your choice (1 or 2): ");
        return int.Parse(Console.ReadLine()) == 1;
    }

    // Get board dimension with validation
    static int GetBoardSize(string dimension)
    {
        int size;
        do
        {
            Console.Write($"Enter number of {dimension} (3-9): ");
            size = int.Parse(Console.ReadLine());
        } while (size < 3 || size > 9);
        return size;
    }

    // Fill board with empty spaces
    static void InitializeBoard(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
            for (int j = 0; j < board.GetLength(1); j++)
                board[i, j] = ' ';
    }

    // Display the game board
    static void DisplayBoard(char[,] board, int rows, int columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int cell = i * columns + j + 1;
                Console.Write(board[i, j] == ' ' ? cell.ToString().PadLeft(2) : $" {board[i, j]}");
                if (j < columns - 1) Console.Write("|");
            }
            Console.WriteLine();
            if (i < rows - 1) Console.WriteLine(new string('-', columns * 3 - 1));
        }
    }

    // Handle player input with undo option
    static int GetPlayerMove(char[,] board, int rows, int columns, char player, Stack<int> moves)
    {
        while (true)
        {
            Console.Write($"Player {player}, enter your move (0 to undo): ");
            int input = int.Parse(Console.ReadLine());
            if (input == 0 && moves.Count > 0)
            {
                int lastMove = moves.Pop();
                PlaceMove(board, lastMove, ' ', columns);
                Console.Clear();
                DisplayBoard(board, rows, columns);
            }
            else if (input > 0 && IsValidMove(board, input, rows, columns))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid move or no move to undo.");
            }
        }
    }

    // Check if move is valid
    static bool IsValidMove(char[,] board, int move, int rows, int columns)
    {
        if (move < 1 || move > rows * columns) return false;
        int row = (move - 1) / columns;
        int col = (move - 1) % columns;
        return board[row, col] == ' ';
    }

    // Place a symbol on the board
    static void PlaceMove(char[,] board, int move, char symbol, int columns)
    {
        int row = (move - 1) / columns;
        int col = (move - 1) % columns;
        board[row, col] = symbol;
    }

    // Check if a player has won
    static bool HasWon(char[,] board, char player, int rows, int columns)
    {
        // Check rows
        for (int i = 0; i < rows; i++)
            if (Enumerable.Range(0, columns).All(j => board[i, j] == player))
                return true;

        // Check columns
        for (int j = 0; j < columns; j++)
            if (Enumerable.Range(0, rows).All(i => board[i, j] == player))
                return true;

        // Check diagonals if square
        if (rows == columns)
        {
            if (Enumerable.Range(0, rows).All(i => board[i, i] == player) ||
                Enumerable.Range(0, rows).All(i => board[i, columns - 1 - i] == player))
                return true;
        }
        return false;
    }

    // Check if game is a draw
    static bool IsDraw(char[,] board, int rows, int columns)
    {
        return IsBoardFull(board, rows, columns) || IsEarlyDraw(board, rows, columns);
    }

    // Check if board is full
    static bool IsBoardFull(char[,] board, int rows, int columns)
    {
        return !Enumerable.Range(0, rows).Any(i => Enumerable.Range(0, columns).Any(j => board[i, j] == ' '));
    }

    // Detect early draw condition
    static bool IsEarlyDraw(char[,] board, int rows, int columns)
    {
        // Check rows
        for (int i = 0; i < rows; i++)
            if (!RowHasBoth(board, i, columns)) return false;

        // Check columns
        for (int j = 0; j < columns; j++)
            if (!ColumnHasBoth(board, j, rows)) return false;

        // Check diagonals if square
        if (rows == columns)
        {
            if (!DiagonalHasBoth(board, rows, true) || !DiagonalHasBoth(board, rows, false))
                return false;
        }
        return true;
    }

    // Helper: Check if row has both 'X' and 'O'
    static bool RowHasBoth(char[,] board, int row, int columns)
    {
        bool hasX = false, hasO = false;
        for (int j = 0; j < columns; j++)
        {
            if (board[row, j] == 'X') hasX = true;
            else if (board[row, j] == 'O') hasO = true;
        }
        return hasX && hasO;
    }

    // Helper: Check if column has both 'X' and 'O'
    static bool ColumnHasBoth(char[,] board, int col, int rows)
    {
        bool hasX = false, hasO = false;
        for (int i = 0; i < rows; i++)
        {
            if (board[i, col] == 'X') hasX = true;
            else if (board[i, col] == 'O') hasO = true;
        }
        return hasX && hasO;
    }

    // Helper: Check if diagonal has both 'X' and 'O'
    static bool DiagonalHasBoth(char[,] board, int size, bool isMain)
    {
        bool hasX = false, hasO = false;
        for (int i = 0; i < size; i++)
        {
            char cell = isMain ? board[i, i] : board[i, size - 1 - i];
            if (cell == 'X') hasX = true;
            else if (cell == 'O') hasO = true;
        }
        return hasX && hasO;
    }

    // Compute computer's move using MiniMax
    static int GetComputerMove(char[,] board, int rows, int columns)
    {
        int bestScore = int.MinValue;
        int bestMove = -1;
        for (int n = 1; n <= rows * columns; n++)
        {
            if (IsValidMove(board, n, rows, columns))
            {
                PlaceMove(board, n, 'O', columns);
                int score = MiniMax(board, 0, false, int.MinValue, int.MaxValue, rows, columns);
                PlaceMove(board, n, ' ', columns);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = n;
                }
            }
        }
        return bestMove;
    }

    // MiniMax algorithm with alpha-beta pruning
    static int MiniMax(char[,] board, int depth, bool isMaximizing, int alpha, int beta, int rows, int columns)
    {
        if (HasWon(board, 'O', rows, columns)) return 10 - depth; // Favor quick wins
        if (HasWon(board, 'X', rows, columns)) return depth - 10; // Delay losses
        if (IsDraw(board, rows, columns)) return 0; // Neutral for draws

        if (isMaximizing)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = 'O';
                        int score = MiniMax(board, depth + 1, false, alpha, beta, rows, columns);
                        board[i, j] = ' ';
                        bestScore = Math.Max(bestScore, score);
                        alpha = Math.Max(alpha, score);
                        if (beta <= alpha) break;
                    }
                }
                if (beta <= alpha) break;
            }
            return bestScore;
        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        board[i, j] = 'X';
                        int score = MiniMax(board, depth + 1, true, alpha, beta, rows, columns);
                        board[i, j] = ' ';
                        bestScore = Math.Min(bestScore, score);
                        beta = Math.Min(beta, score);
                        if (beta <= alpha) break;
                    }
                }
                if (beta <= alpha) break;
            }
            return bestScore;
        }
    }
}