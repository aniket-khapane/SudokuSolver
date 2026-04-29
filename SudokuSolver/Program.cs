namespace SudokuSolver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Sudoku solver;
            Console.WriteLine("Welcome to the Sudoku Solver!");
            Console.WriteLine("Please select a solver:");
            Console.WriteLine("1. Sudoku_claude");
            Console.WriteLine("2. Sudoku_copilot");
            var selected_solver = Console.ReadKey();
            if (selected_solver.KeyChar == '1')
            {
                solver = new Sudoku_claude();
            }
            else
            {
                solver = new Sudoku_copilot();
            }


            // Example from the problem
            char[][] board = new char[][]
            {
            new char[] {'5','3','.','.','7','.','.','.','.'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            Console.WriteLine(Environment.NewLine + "Initial Sudoku Board:");
            solver.PrintBoard(board);

            Console.WriteLine("\n\nSolving...\n");
            solver.SolveSudoku(board);

            Console.WriteLine("Solved Sudoku Board:");
            solver.PrintBoard(board);
        }
    }
}
