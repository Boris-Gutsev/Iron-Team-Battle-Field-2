// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BattleFieldFrameworkTest.cs" company="">
//   
// </copyright>
// <summary>
//   The battle field framefork test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BattleField.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The battle field framefork test.
    /// </summary>
    [TestClass]
    public class BattleFieldFrameworkTest
    {
        #region Constructor

        /// <summary>
        /// The battle field framework constructor negative test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BattleFieldFrameworkConstructorNegativeTest()
        {
            BattleFieldFramework bf = new BattleFieldFramework(0);
        }

        /// <summary>
        /// The battle field framework constructor size 4.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkConstructorSize4()
        {
            BattleFieldFramework bf = new BattleFieldFramework(4);
            int exprected = 4;
            int actual = bf.FieldSize;
            Assert.AreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework constructor detonate mines size 4.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkConstructorDetonateMinesSize4()
        {
            BattleFieldFramework bf = new BattleFieldFramework(4);
            int exprected = 0;
            int actual = bf.DetonatedMines;
            Assert.AreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework constructor init field size 4.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkConstructorInitFieldSize4()
        {
            int size = 4;
            BattleFieldFramework bf = new BattleFieldFramework(size);
            string[,] actual = bf.Playground;

            string[,] exprected =
                {
                    { " - ", " - ", " - ", " - " }, { " - ", " - ", " - ", " - " }, 
                    { " - ", " - ", " - ", " - " }, { " - ", " - ", " - ", " - " }
                };

            this.AssertMatrixAreEqual(exprected, actual);
        }

        #endregion

        #region Playground initialization

        /// <summary>
        /// The battle field framework get number of mines size 1.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize1()
        {
            BattleFieldFramework bf = new BattleFieldFramework(1);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 0;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        /// <summary>
        /// The battle field framework get number of mines size 2.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize2()
        {
            BattleFieldFramework bf = new BattleFieldFramework(2);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 1;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        /// <summary>
        /// The battle field framework get number of mines size 5.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize5()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 7;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        /// <summary>
        /// The battle field framework get number of mines size 10.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize10()
        {
            BattleFieldFramework bf = new BattleFieldFramework(10);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 29;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        /// <summary>
        /// The battle field framework init mines size 1.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize1()
        {
            BattleFieldFramework bf = new BattleFieldFramework(1);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected = { { " 5 " }, };
            AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework init mines size 2.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize2()
        {
            BattleFieldFramework bf = new BattleFieldFramework(2);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected = { { " - ", " - ", }, { " - ", " 5 ", }, };
            AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework init mines size 5.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize5()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected =
                {
                    { " 4 ", " - ", " - ", " - ", " - " }, { " - ", " - ", " - ", " - ", " - " }, 
                    { " 5 ", " 1 ", " - ", " - ", " - " }, { " 1 ", " - ", " - ", " - ", " - " }, 
                    { " 1 ", " - ", " 1 ", " 5 ", " - " }, 
                };
            AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework init mines size 10.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize10()
        {
            BattleFieldFramework bf = new BattleFieldFramework(10);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected =
                {
                    { " - ", " - ", " 3 ", " - ", " - ", " 1 ", " - ", " 1 ", " - ", " - " }, 
                    { " - ", " 4 ", " - ", " 1 ", " - ", " - ", " - ", " - ", " - ", " - " }, 
                    { " - ", " - ", " 4 ", " - ", " - ", " - ", " - ", " - ", " - ", " - " }, 
                    { " - ", " 3 ", " - ", " 5 ", " - ", " - ", " - ", " - ", " 2 ", " - " }, 
                    { " 5 ", " 4 ", " - ", " - ", " 5 ", " - ", " - ", " - ", " 2 ", " - " }, 
                    { " - ", " 3 ", " 1 ", " - ", " - ", " - ", " - ", " - ", " 4 ", " - " }, 
                    { " 1 ", " - ", " - ", " 1 ", " 2 ", " - ", " - ", " - ", " - ", " - " }, 
                    { " 1 ", " 1 ", " - ", " - ", " - ", " - ", " 4 ", " - ", " - ", " 5 " }, 
                    { " - ", " - ", " - ", " - ", " - ", " 1 ", " - ", " - ", " - ", " 5 " }, 
                    { " - ", " 1 ", " 3 ", " - ", " 1 ", " - ", " - ", " 5 ", " - ", " - " }, 
                };
            AssertMatrixAreEqual(exprected, actual);
        }

        #endregion

        #region Detonate mines

        /// <summary>
        /// The battle field framework detonate size 1 mine 5.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize1Mine5()
        {
            BattleFieldFramework bf = new BattleFieldFramework(1);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] actual = bf.DetonateMine(playGround, 0, 0);

            string[,] exprected = { { " X " }, };
            AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework detonate size 5 mine 1.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine1()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] actual = bf.DetonateMine(playGround, 2, 1);

            string[,] exprected =
                {
                    { " 4 ", " - ", " - ", " - ", " - " }, { " X ", " - ", " X ", " - ", " - " }, 
                    { " 5 ", " X ", " - ", " - ", " - " }, { " X ", " - ", " X ", " - ", " - " }, 
                    { " 1 ", " - ", " 1 ", " 5 ", " - " }, 
                };
            this.AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework detonate size 5 mine 5 after 1.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine5After1()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playGround, 2, 1);
            string[,] actual = bf.DetonateMine(first, 4, 3);

            string[,] exprected =
                {
                    { " 4 ", " - ", " - ", " - ", " - " }, { " X ", " - ", " X ", " - ", " - " }, 
                    { " 5 ", " X ", " X ", " X ", " X " }, { " X ", " X ", " X ", " X ", " X " }, 
                    { " 1 ", " X ", " X ", " X ", " X " }, 
                };
            this.AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework detonate size 5 mine 4 after 1 and 5.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine4After1And5()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playGround, 2, 1);
            string[,] second = bf.DetonateMine(first, 4, 3);
            string[,] actual = bf.DetonateMine(second, 0, 0);

            string[,] exprected =
                {
                    { " X ", " X ", " X ", " - ", " - " }, { " X ", " X ", " X ", " - ", " - " }, 
                    { " X ", " X ", " X ", " X ", " X " }, { " X ", " X ", " X ", " X ", " X " }, 
                    { " 1 ", " X ", " X ", " X ", " X " }, 
                };
            this.AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework detonate size 5 mine 1 after 1 and 5 and 4.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine1After1And5And4()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playGround, 2, 1);
            string[,] second = bf.DetonateMine(first, 4, 3);
            string[,] third = bf.DetonateMine(second, 0, 0);
            string[,] actual = bf.DetonateMine(third, 4, 0);

            string[,] exprected =
                {
                    { " X ", " X ", " X ", " - ", " - " }, { " X ", " X ", " X ", " - ", " - " }, 
                    { " X ", " X ", " X ", " X ", " X " }, { " X ", " X ", " X ", " X ", " X " }, 
                    { " X ", " X ", " X ", " X ", " X " }, 
                };
            AssertMatrixAreEqual(exprected, actual);
        }

        /// <summary>
        /// The battle field framework detonate size 5 game over count unopen mines.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5GameOverCountUnopenMines()
        {
            BattleFieldFramework bf = new BattleFieldFramework(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playGround, 2, 1);
            string[,] second = bf.DetonateMine(first, 4, 3);
            string[,] third = bf.DetonateMine(second, 0, 0);
            string[,] actual = bf.DetonateMine(third, 4, 0);

            string[,] exprected =
                {
                    { " X ", " X ", " X ", " - ", " - " }, { " X ", " X ", " X ", " - ", " - " }, 
                    { " X ", " X ", " X ", " X ", " X " }, { " X ", " X ", " X ", " X ", " X " }, 
                    { " X ", " X ", " X ", " X ", " X " }, 
                };
            AssertMatrixAreEqual(exprected, actual);
            Assert.AreEqual(0, bf.CountRemainingMines());
        }

        /// <summary>
        /// The battle field framework detonate size 10 mine 2.
        /// </summary>
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize10Mine2()
        {
            BattleFieldFramework bf = new BattleFieldFramework(10);
            Random randomGenerator = new Random(256);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playGround = bf.InitMines(randomGenerator, numberOfMines);
            string[,] actual = bf.DetonateMine(playGround, 6, 2);

            string[,] exprected =
                {
                    { " 2 ", " - ", " - ", " - ", " - ", " 3 ", " - ", " - ", " 1 ", " - " }, 
                    { " 2 ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " }, 
                    { " - ", " - ", " 4 ", " - ", " 4 ", " - ", " - ", " - ", " - ", " - " }, 
                    { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - " }, 
                    { " - ", " 1 ", " - ", " - ", " - ", " - ", " - ", " 4 ", " 4 ", " 1 " }, 
                    { " - ", " X ", " X ", " X ", " - ", " - ", " - ", " - ", " - ", " - " }, 
                    { " - ", " X ", " X ", " X ", " - ", " - ", " 3 ", " - ", " - ", " - " }, 
                    { " - ", " X ", " X ", " X ", " - ", " 1 ", " - ", " - ", " - ", " - " }, 
                    { " - ", " 2 ", " 3 ", " 4 ", " - ", " - ", " 4 ", " - ", " - ", " - " }, 
                    { " - ", " - ", " - ", " - ", " - ", " - ", " - ", " 1 ", " - ", " - " }, 
                };
            AssertMatrixAreEqual(exprected, actual);
        }

        #endregion

        #region Matrices equlility
        /// <summary>
        /// The assert matrix are equal.
        /// </summary>
        /// <param name="expectedMatrix">
        /// The expected matrix.
        /// </param>
        /// <param name="actualMatrix">
        /// The actual matrix.
        /// </param>
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
        #endregion
    }
}