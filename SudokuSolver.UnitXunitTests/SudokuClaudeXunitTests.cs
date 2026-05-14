using Xunit;
using SudokuSolver;

namespace SudokuSolver
{
    public class SudokuClaudeXunitTests
    {
        [Fact]
        public void SolveSudoku_NullBoard_DoesNotThrowAndRemainsNull()
        {
            char[][]? board = null;
            var sut = new Sudoku_claude();
            sut.SolveSudoku(board);
            Assert.Null(board);
        }

        [Fact]
        public void SolveSudoku_EmptyBoard_DoesNotThrowAndRemainsEmpty()
        {
            char[][] board = new char[0][];
            var sut = new Sudoku_claude();
            sut.SolveSudoku(board);
            Assert.Empty(board);
        }
    }
}
