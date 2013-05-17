using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleField.Test
{
    [TestClass]
    public class BattleFieldFrameforkTest
    {
        #region Constructor
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BattleFieldFrameworkConstructorNegativeTest()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(0);
        }

        [TestMethod]
        public void BattleFieldFrameworkConstructorSize4()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(4);
            int exprected = 4;
            int actual = bf.FieldSize;
            Assert.AreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkConstructorDetonateMinesSize4()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(4);
            int exprected = 0;
            int actual = bf.DetonatedMines;
            Assert.AreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkConstructorInitFieldSize4()
        {
            int size = 4;
            BattleFieldFramefork bf = new BattleFieldFramefork(size);
            string[,] actual = bf.Playground;

            string[,] exprected = {
                                    { " - ", " - ", " - ", " - " },
                                    { " - ", " - ", " - ", " - " },
                                    { " - ", " - ", " - ", " - " },
                                    { " - ", " - ", " - ", " - " }
                                  };           

            AssertMatrixAreEqual(exprected, actual);
        }
        #endregion

        #region Playground initialization
        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize1()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(1);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 0;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize2()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(2);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 1;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize5()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 7;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        [TestMethod]
        public void BattleFieldFrameworkGetNumberOfMinesSize10()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(10);
            Random randomGenerator = new Random(123);
            int actualeNumberOfMines = bf.GetNumberOfMines(randomGenerator);
            int expect = 29;
            Assert.AreEqual(expect, actualeNumberOfMines);
        }

        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize1()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(1);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected = {
                                    { " 5 " },                                    
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize2()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(2);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected = {
                                    { " - ", " - ", },
                                    { " - ", " 5 ", },
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize5()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected = {
                                    { " 4 "," - "," - "," - "," - "},
                                    { " - "," - "," - "," - "," - "},
                                    { " 5 "," 1 "," - "," - "," - "},
                                    { " 1 "," - "," - "," - "," - "},
                                    { " 1 "," - "," 1 "," 5 "," - "},
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }


        [TestMethod]
        public void BattleFieldFrameworkInitMinesSize10()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(10);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] actual = bf.InitMines(randomGenerator, numberOfMines);

            string[,] exprected = {
                                    { " - "," - "," 3 "," - "," - "," 1 "," - "," 1 "," - "," - "},
                                    { " - "," 4 "," - "," 1 "," - "," - "," - "," - "," - "," - "},
                                    { " - "," - "," 4 "," - "," - "," - "," - "," - "," - "," - "},
                                    { " - "," 3 "," - "," 5 "," - "," - "," - "," - "," 2 "," - "},
                                    { " 5 "," 4 "," - "," - "," 5 "," - "," - "," - "," 2 "," - "},
                                    { " - "," 3 "," 1 "," - "," - "," - "," - "," - "," 4 "," - "},
                                    { " 1 "," - "," - "," 1 "," 2 "," - "," - "," - "," - "," - "},
                                    { " 1 "," 1 "," - "," - "," - "," - "," 4 "," - "," - "," 5 "},
                                    { " - "," - "," - "," - "," - "," 1 "," - "," - "," - "," 5 "},
                                    { " - "," 1 "," 3 "," - "," 1 "," - "," - "," 5 "," - "," - "},
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }
        #endregion

        #region Detonate mines
        [TestMethod]
        public void BattleFieldFrameworkDetonateSize1Mine5()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(1);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] actual = bf.DetonateMine(playgraund, 0, 0);

            string[,] exprected = {
                                    { " X " },                                    
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine1()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] actual = bf.DetonateMine(playgraund, 2, 1);

            string[,] exprected = {
                                    { " 4 "," - "," - "," - "," - "},
                                    { " X "," - "," X "," - "," - "},
                                    { " 5 "," X "," - "," - "," - "},
                                    { " X "," - "," X "," - "," - "},
                                    { " 1 "," - "," 1 "," 5 "," - "},                                  
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine5After1()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playgraund, 2, 1);
            string[,] actual = bf.DetonateMine(first, 4, 3);

            string[,] exprected = {
                                    { " 4 "," - "," - "," - "," - "},
                                    { " X "," - "," X "," - "," - "},
                                    { " 5 "," X "," X "," X "," X "},
                                    { " X "," X "," X "," X "," X "},
                                    { " 1 "," X "," X "," X "," X "},                               
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine4After1and5()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playgraund, 2, 1);
            string[,] second = bf.DetonateMine(first, 4, 3);
            string[,] actual = bf.DetonateMine(second, 0, 0);

            string[,] exprected = {
                                    { " X "," X "," X "," - "," - "},
                                    { " X "," X "," X "," - "," - "},
                                    { " X "," X "," X "," X "," X "},
                                    { " X "," X "," X "," X "," X "},
                                    { " 1 "," X "," X "," X "," X "},                              
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5Mine1After1and5and4()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playgraund, 2, 1);
            string[,] second = bf.DetonateMine(first, 4, 3);
            string[,] thread = bf.DetonateMine(second, 0, 0);
            string[,] actual = bf.DetonateMine(thread, 4, 0);

            string[,] exprected = {
                                    { " X "," X "," X "," - "," - "},
                                    { " X "," X "," X "," - "," - "},
                                    { " X "," X "," X "," X "," X "},
                                    { " X "," X "," X "," X "," X "},
                                    { " X "," X "," X "," X "," X "},                              
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }

        [TestMethod]
        public void BattleFieldFrameworkDetonateSize5GameOverCountUnopenMines()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(5);
            Random randomGenerator = new Random(123);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] first = bf.DetonateMine(playgraund, 2, 1);
            string[,] second = bf.DetonateMine(first, 4, 3);
            string[,] thread = bf.DetonateMine(second, 0, 0);
            string[,] actual = bf.DetonateMine(thread, 4, 0);

            string[,] exprected = {
                                    { " X "," X "," X "," - "," - "},
                                    { " X "," X "," X "," - "," - "},
                                    { " X "," X "," X "," X "," X "},
                                    { " X "," X "," X "," X "," X "},
                                    { " X "," X "," X "," X "," X "},                              
                                  };
            AssertMatrixAreEqual(exprected, actual);          
            Assert.AreEqual(0, bf.PrebroiOstavashtiteMinichki());
        }

        [TestMethod]
        public void BattleFieldFrameworkDetonateSize10Mine2()
        {
            BattleFieldFramefork bf = new BattleFieldFramefork(10);
            Random randomGenerator = new Random(256);
            int numberOfMines = bf.GetNumberOfMines(randomGenerator);
            string[,] playgraund = bf.InitMines(randomGenerator, numberOfMines);
            string[,] actual = bf.DetonateMine(playgraund, 6, 2);

            string[,] exprected = {
                                    { " 2 "," - "," - "," - "," - "," 3 "," - "," - "," 1 "," - "},
                                    { " 2 "," - "," - "," - "," - "," - "," - "," - "," - "," - "},
                                    { " - "," - "," 4 "," - "," 4 "," - "," - "," - "," - "," - "},
                                    { " - "," - "," - "," - "," - "," - "," - "," - "," - "," - "},
                                    { " - "," 1 "," - "," - "," - "," - "," - "," 4 "," 4 "," 1 "},
                                    { " - "," X "," X "," X "," - "," - "," - "," - "," - "," - "},
                                    { " - "," X "," X "," X "," - "," - "," 3 "," - "," - "," - "},
                                    { " - "," X "," X "," X "," - "," 1 "," - "," - "," - "," - "},
                                    { " - "," 2 "," 3 "," 4 "," - "," - "," 4 "," - "," - "," - "},
                                    { " - "," - "," - "," - "," - "," - "," - "," 1 "," - "," - "},                              
                                  };
            AssertMatrixAreEqual(exprected, actual);
        }
        #endregion



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
