using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    internal class Sudoku_claude: Sudoku
    {
        public override void SolveSudoku(char[][] board)
        {
            if (board == null || board.Length == 0)
                return;

            Solve(board);
        }

        private bool Solve(char[][] board)
        {
            // Find the next empty cell
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // If cell is empty, try to fill it
                    if (board[row][col] == '.')
                    {
                        // Try each digit 1-9
                        for (char digit = '1'; digit <= '9'; digit++)
                        {
                            // Check if placing this digit is valid
                            if (IsValid(board, row, col, digit))
                            {
                                // Place the digit
                                board[row][col] = digit;

                                // Recursively try to solve the rest of the puzzle
                                if (Solve(board))
                                    return true;

                                // Backtrack if no solution found
                                board[row][col] = '.';
                            }
                        }

                        // No valid digit found for this cell, backtrack
                        return false;
                    }
                }
            }

            // All cells filled successfully
            return true;
        }

        private bool IsValid(char[][] board, int row, int col, char digit)
        {
            // Check if digit already exists in the row
            for (int c = 0; c < 9; c++)
            {
                if (board[row][c] == digit)
                    return false;
            }

            // Check if digit already exists in the column
            for (int r = 0; r < 9; r++)
            {
                if (board[r][col] == digit)
                    return false;
            }

            // Check if digit already exists in the 3x3 box
            int boxRow = (row / 3) * 3;
            int boxCol = (col / 3) * 3;

            for (int r = boxRow; r < boxRow + 3; r++)
            {
                for (int c = boxCol; c < boxCol + 3; c++)
                {
                    if (board[r][c] == digit)
                        return false;
                }
            }

            return true;
        }
    }
}