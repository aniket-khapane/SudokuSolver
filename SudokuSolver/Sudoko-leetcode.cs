using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SudokuSolver
{
    internal class Sudoko_leetcode : Sudoku
    {
        public override void SolveSudoku(char[][] board)
        {
            int[] rowMasks = new int[9];
            int[] colMasks = new int[9];
            int[] boxMasks = new int[9];

            int[] emptyCells = new int[81];
            int emptyCount = 0;

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] == '.')
                    {
                        emptyCells[emptyCount++] = r * 9 + c;
                    }
                    else
                    {
                        int val = board[r][c] - '0';
                        int bit = 1 << val;
                        rowMasks[r] |= bit;
                        colMasks[c] |= bit;

                        int b = (r / 3) * 3 + (c / 3);
                        boxMasks[b] |= bit;
                    }
                }
            }

            Solve(board, emptyCells, emptyCount, rowMasks, colMasks, boxMasks);
        }

        private bool Solve(char[][] board, int[] emptyCells, int emptyCount, int[] rowMasks, int[] colMasks, int[] boxMasks)
        {
            if (emptyCount == 0) return true;

            int bestIdx = -1;
            int minOptionsCount = 10;
            int bestCellValidMask = 0;

            for (int i = 0; i < emptyCount; i++)
            {
                int cell = emptyCells[i];
                int r = cell / 9;
                int c = cell % 9;
                int b = (r / 3) * 3 + (c / 3);

                int usedMask = rowMasks[r] | colMasks[c] | boxMasks[b];

                int availableMask = ~usedMask & 0x3FE;
                int optionsCount = BitOperations.PopCount((uint)availableMask);

                if (optionsCount == 0) return false;

                if (optionsCount < minOptionsCount)
                {
                    minOptionsCount = optionsCount;
                    bestIdx = i;
                    bestCellValidMask = availableMask;

                    if (optionsCount == 1) break;
                }
            }

            int bestCell = emptyCells[bestIdx];
            int cellR = bestCell / 9;
            int cellC = bestCell % 9;
            int cellB = (cellR / 3) * 3 + (cellC / 3);

            emptyCells[bestIdx] = emptyCells[emptyCount - 1];
            emptyCells[emptyCount - 1] = bestCell;

            for (int num = 1; num <= 9; num++)
            {
                int bit = 1 << num;

                if ((bestCellValidMask & bit) != 0)
                {
                    board[cellR][cellC] = (char)(num + '0');
                    rowMasks[cellR] |= bit;
                    colMasks[cellC] |= bit;
                    boxMasks[cellB] |= bit;

                    if (Solve(board, emptyCells, emptyCount - 1, rowMasks, colMasks, boxMasks))
                    {
                        return true;
                    }

                    board[cellR][cellC] = '.';
                    rowMasks[cellR] &= ~bit;
                    colMasks[cellC] &= ~bit;
                    boxMasks[cellB] &= ~bit;
                }
            }

            emptyCells[emptyCount - 1] = emptyCells[bestIdx];
            emptyCells[bestIdx] = bestCell;

            return false;
        }
    }
}