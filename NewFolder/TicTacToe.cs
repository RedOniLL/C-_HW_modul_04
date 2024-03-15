using System;


namespace C__HW_modul_04.NewFolder
{
    public class TicTacToe
    {
        private char[,] board;
        private char currentPlayer;
        private bool vsComputer;
        private Random random;

        public TicTacToe(bool vsComputer)
        {
            board = new char[3, 3];
            currentPlayer = 'X'; 
            this.vsComputer = vsComputer;
            random = new Random();
            InitializeBoard();
            PrintBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        private void PrintBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        private bool PlaceMarker(int row, int col)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '-')
            {
                board[row, col] = currentPlayer;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckForWin()
        {
            return (CheckRowsForWin() || CheckColumnsForWin() || CheckDiagonalsForWin());
        }

        private bool CheckRowsForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '-' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumnsForWin()
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != '-' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonalsForWin()
        {
            return ((board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
                    (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]));
        }

        private bool IsBoardFull()
        {
            foreach (char marker in board)
            {
                if (marker == '-')
                {
                    return false;
                }
            }
            return true;
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        private void ComputerMove()
        {
            int row, col;
            do
            {
                row = random.Next(0, 3);
                col = random.Next(0, 3);
            } while (!PlaceMarker(row, col));
        }

        public void Play()
        {
            while (true)
            {
                int row, col;
                if (vsComputer && currentPlayer == 'O')
                {
                    ComputerMove();
                }
                else
                {
                    Console.WriteLine($"Player {currentPlayer}'s turn.");
                    do
                    {
                        Console.Write("Enter row number (0-2): ");
                        row = int.Parse(Console.ReadLine());
                        Console.Write("Enter column number (0-2): ");
                        col = int.Parse(Console.ReadLine());
                    } while (!PlaceMarker(row, col));
                }
                PrintBoard();
                if (CheckForWin())
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    break;
                }
                else if (IsBoardFull())
                {
                    Console.WriteLine("It's a draw!");
                    break;
                }
                SwitchPlayer();
            }
        }
    }
}
