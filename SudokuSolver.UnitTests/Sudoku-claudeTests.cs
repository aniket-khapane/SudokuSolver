#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuSolver;
using System;
using System.Collections;
using System.Linq;


namespace SudokuSolver.UnitTests
{
    [TestClass]
    public class Sudoku_claudeTests
    {
        /// <summary>
        /// Verifies that calling SolveSudoku with a null board does not throw and leaves the reference null.
        /// Input: board = null
        /// Expected: Method returns without throwing and board remains null.
        /// </summary>
        [TestMethod]
        public void SolveSudoku_NullBoard_DoesNotThrowAndRemainsNull()
        {
            // Arrange
            char[][]? board = null;
            var sut = new Sudoku_claude();

            // Act
            sut.SolveSudoku(board);

            // Assert
            Assert.IsNull(board);
        }

        /// <summary>
        /// Verifies that calling SolveSudoku with an empty array (length == 0) does not throw and leaves it unchanged.
        /// Input: board = new char[0][]
        /// Expected: Method returns without throwing and board.Length == 0.
        /// </summary>
        [TestMethod]
        public void SolveSudoku_EmptyBoard_DoesNotThrowAndRemainsEmpty()
        {
            // Arrange
            char[][] board = new char[0][];
            var sut = new Sudoku_claude();

            // Act
            sut.SolveSudoku(board);

            // Assert
            Assert.AreEqual(0, board.Length);
        }

    }
}