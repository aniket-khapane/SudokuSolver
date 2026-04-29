using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    internal class Sudoku_copilot: Sudoku
    {

        public override void SolveSudoku(char[][] board)
        {
            Solve(board);
        }

        private bool Solve(char[][] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        for (char num = '1'; num <= '9'; num++)
                        {
                            if (IsValid(board, row, col, num))
                            {
                                board[row][col] = num;

                                if (Solve(board))
                                    return true;

                                board[row][col] = '.'; // backtrack
                            }
                        }
                        return false; // no valid number found
                    }
                }
            }
            return true; // solved
        }

        private bool IsValid(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                // Check row
                if (board[row][i] == c) return false;

                // Check column
                if (board[i][col] == c) return false;

                // Check 3×3 subgrid
                int subRow = 3 * (row / 3) + i / 3;
                int subCol = 3 * (col / 3) + i % 3;
                if (board[subRow][subCol] == c) return false;
            }
            return true;
        }


    }
}
