using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Test
{
    [TestClass]
    public class BattleFieldFrameforkTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BattleFieldFrameforkConstructorNegativeTest()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(0);
        }

        [TestMethod]
        public void BattleFieldFrameforkConstructorNormalTest()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(4);

            int exprected = 4;
            int actual = bf.FieldSize;
            Assert.AreEqual(exprected, actual);
        }


        [TestMethod]
        public void BattleFieldFrameforkInitFieldTest()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(4);
            bf.InitField();

            string[,] exprected =
                {
                    { " - ", " - ", " - ", " - " }, { " - ", " - ", " - ", " - " },
                    { " - ", " - ", " - ", " - " }, { " - ", " - ", " - ", " - " }
                };

            string[,] actual = bf.Positions; // TODO

            this.AssertMatrixAreEqual(exprected, actual);
        }

        private void AssertMatrixAreEqual(string[,] expectedMatrix, string[,] actualMatrix)
        {
            Assert.IsNotNull(expectedMatrix);
            Assert.IsNotNull(actualMatrix);

            int rowsCountExpectedMatrix = expectedMatrix.GetLength(0);
            int rowsCountActualMatrix = actualMatrix.GetLength(0);
            Assert.AreEqual(rowsCountExpectedMatrix, rowsCountActualMatrix);

            int columnsCountExpectedMatrix = expectedMatrix.GetLength(1);
            int columnsCountActualMatrix = actualMatrix.GetLength(1);
            Assert.AreEqual(columnsCountExpectedMatrix, columnsCountActualMatrix);

            for (int row = 0; row < rowsCountExpectedMatrix; row++)
            {
                for (int column = 0; column < columnsCountExpectedMatrix; column++)
                {
                    string expectedChar = expectedMatrix[row, column];
                    string actualChar = actualMatrix[row, column];
                    Assert.AreEqual(expectedChar, actualChar);
                }
            }
        }
    }
}
