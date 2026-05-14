using NUnit.Framework;
using SudokuSolver;

namespace SudokuSolver.Tests
{
    public class SudokuSolverSolverTests
    {
        [Test]
        public void SolveSudoku_EasyPuzzle_SolvesCorrectly()
        {
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
            var solver = new Sudoku_claude();
            solver.SolveSudoku(board);
            Assert.AreEqual('5', board[0][0]);
            Assert.AreEqual('9', board[4][4]);
            Assert.AreEqual('2', board[6][0]);
        }

        [Test]
        public void SolveSudoku_MediumPuzzle_SolvesCorrectly()
        {
            char[][] board = new char[][]
            {
                new char[] {'.','.','3','.','2','.','6','.','.'},
                new char[] {'9','.','.','3','.','5','.','.','1'},
                new char[] {'.','.','1','8','.','6','4','.','.'},
                new char[] {'.','.','8','1','.','2','9','.','.'},
                new char[] {'.','.','.','.','.','.','.','.','.'},
                new char[] {'.','.','2','7','.','4','8','.','.'},
                new char[] {'.','.','6','5','.','8','2','.','.'},
                new char[] {'2','.','.','4','.','9','.','.','8'},
                new char[] {'.','.','4','.','1','.','3','.','.'}
            };
            var solver = new Sudoku_copilot();
            solver.SolveSudoku(board);
            Assert.AreEqual('5', board[0][0]);
            Assert.AreEqual('1', board[4][4]);
            Assert.AreEqual('3', board[8][6]);
        }

        [Test]
        public void SolveSudoku_UnsolvablePuzzle_DoesNotThrow()
        {
            char[][] board = new char[][]
            {
                new char[] {'5','5','.','.','7','.','.','.','.'}, // Invalid: two 5's in row
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };
            var solver = new Sudoku_claude();
            Assert.DoesNotThrow(() => solver.SolveSudoku(board));
        }
    }
}
