using Xunit;
using SudokuSolver;
using System;

namespace SudokuSolver.UnitXunitTests
{
    public class SudokuCopilotXunitTests
    {
        [Fact]
        public void SolveSudoku_NullBoard_ExpectedArgumentNullExceptionOrHandled()
        {
            char[][]? board = null;
            var sutType = typeof(Sudoku_copilot);
            var sut = Activator.CreateInstance(sutType);
            var method = sutType.GetMethod("SolveSudoku");
            Assert.NotNull(method);
            try
            {
                method.Invoke(sut, new object?[] { null! });
                Assert.True(true); // No exception, handled gracefully
            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                if (tie.InnerException is ArgumentNullException)
                {
                    Assert.True(true); // Expected
                }
                else
                {
                    Assert.True(false, $"Unexpected exception: {tie.InnerException?.Message ?? tie.Message}");
                }
            }
            catch (ArgumentNullException)
            {
                Assert.True(true); // Expected
            }
        }
    }
}
