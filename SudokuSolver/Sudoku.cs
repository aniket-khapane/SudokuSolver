using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    internal abstract class Sudoku
    {
        public abstract void SolveSudoku(char[][] board);

        public void PrintBoard(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                    Console.WriteLine("-----------");

                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                        Console.Write("| ");

                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
