// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BattleFieldFramework.cs" company="Telerik">
//   
// </copyright>
// <summary>
//   The battle field framework.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BattleField
{
    using System;

    /// <summary>
    /// The battle field game framework.
    /// </summary>
    public class BattleFieldFramework
    {
        #region Constants

        /// <summary>
        /// The explosio n_ mark.
        /// </summary>
        private const string EXPLOSION_MARK = " X ";

        #endregion

        #region Fields

        /// <summary>
        /// The field size.
        /// </summary>
        private int fieldSize;

        /// <summary>
        /// The playground.
        /// </summary>
        private string[,] playground;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleFieldFramework"/> class.
        /// </summary>
        /// <param name="fieldSize">
        /// The field size.
        /// </param>
        public BattleFieldFramework(int fieldSize)
        {
            this.FieldSize = fieldSize;
            this.Playground = this.InitializationEmptyPlayground(this.FieldSize);
            this.DetonatedMines = 0;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the detonated mines.
        /// </summary>
        public int DetonatedMines { get; set; }

        /// <summary>
        /// Gets the field size.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// throws ex
        /// </exception>
        public int FieldSize
        {
            get
            {
                return this.fieldSize;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fieldsize cannot be negative or zero");
                }

                this.fieldSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the playground.
        /// </summary>
        public string[,] Playground
        {
            get
            {
                return this.playground;
            }

            set
            {
                this.playground = value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Counts the remaining mines
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CountRemainingMines()
        {
            int count = 0;

            for (int row = 0; row < this.fieldSize; row++)
            {
                for (int col = 0; col < this.fieldSize; col++)
                {
                    if ((this.playground[row, col] != " X ") && (this.playground[row, col] != " - "))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        ///  Detonates mine
        /// </summary>
        /// <param name="currentPlayground">
        ///  The current playground.
        /// </param>
        /// <param name="xCoord">
        ///  The x coord.
        /// </param>
        /// <param name="yCoord">
        /// The y coord.
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public string[,] DetonateMine(string[,] currentPlayground, int xCoord, int yCoord)
        {
            int minesType = int.Parse(currentPlayground[xCoord, yCoord]);
            string[,] detonatePlayground;
            switch (minesType)
            {
                case 1:
                    detonatePlayground = this.DetonateMine1(currentPlayground, xCoord, yCoord);
                    break;
                case 2:
                    detonatePlayground = this.DetonateMine2(currentPlayground, xCoord, yCoord);
                    break;
                case 3:
                    detonatePlayground = this.DetonateMine3(currentPlayground, xCoord, yCoord);
                    break;
                case 4:
                    detonatePlayground = this.DetonateMine4(currentPlayground, xCoord, yCoord);
                    break;
                case 5:
                    detonatePlayground = this.DetonateMine5(currentPlayground, xCoord, yCoord);
                    break;
                default:
                    throw new ArgumentException("Mines type are 1 - 5. You tried to open " + minesType);
            }

            return detonatePlayground;
        }

        /// <summary>
        /// The detonate mine 1.
        /// </summary>
        /// <param name="currentPlayground">
        /// The current playground.
        /// </param>
        /// <param name="positionX">
        /// The position x.
        /// </param>
        /// <param name="positionY">
        /// The position y.
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        public string[,] DetonateMine1(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = currentPlayground;
            this.Explode(detonateMatrix, positionX, positionY);
            this.Explode(detonateMatrix, positionX - 1, positionY - 1);
            this.Explode(detonateMatrix, positionX - 1, positionY + 1);
            this.Explode(detonateMatrix, positionX + 1, positionY - 1);
            this.Explode(detonateMatrix, positionX + 1, positionY + 1);
            return detonateMatrix;
        }

        /// <summary>
        /// The detonate mine 2.
        /// </summary>
        /// <param name="currentPlayground">
        /// The current playground.
        /// </param>
        /// <param name="positionX">
        /// The position x.
        /// </param>
        /// <param name="positionY">
        /// The position y.
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        public string[,] DetonateMine2(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = this.DetonateMine1(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX, positionY - 1);
            this.Explode(detonateMatrix, positionX - 1, positionY);
            this.Explode(detonateMatrix, positionX + 1, positionY);
            this.Explode(detonateMatrix, positionX, positionY + 1);
            return detonateMatrix;
        }

        /// <summary>
        /// The detonate mine 3.
        /// </summary>
        /// <param name="currentPlayground">
        /// The current playground.
        /// </param>
        /// <param name="positionX">
        /// The position x.
        /// </param>
        /// <param name="positionY">
        /// The position y.
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        public string[,] DetonateMine3(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = this.DetonateMine2(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX - 2, positionY);
            this.Explode(detonateMatrix, positionX + 2, positionY);
            this.Explode(detonateMatrix, positionX, positionY - 2);
            this.Explode(detonateMatrix, positionX, positionY + 2);
            return detonateMatrix;
        }

        /// <summary>
        /// The detonate mine 4.
        /// </summary>
        /// <param name="currentPlayground">
        /// The current playground.
        /// </param>
        /// <param name="positionX">
        /// The position x.
        /// </param>
        /// <param name="positionY">
        /// The position y.
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        public string[,] DetonateMine4(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = this.DetonateMine3(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX - 1, positionY + 2);
            this.Explode(detonateMatrix, positionX + 1, positionY + 2);
            this.Explode(detonateMatrix, positionX - 1, positionY - 2);
            this.Explode(detonateMatrix, positionX + 1, positionY - 2);
            this.Explode(detonateMatrix, positionX - 2, positionY - 1);
            this.Explode(detonateMatrix, positionX - 2, positionY + 1);
            this.Explode(detonateMatrix, positionX + 2, positionY - 1);
            this.Explode(detonateMatrix, positionX + 2, positionY + 1);
            return detonateMatrix;
        }

        /// <summary>
        /// The detonate mine 5.
        /// </summary>
        /// <param name="currentPlayground">
        /// The current playground.
        /// </param>
        /// <param name="positionX">
        /// The position x.
        /// </param>
        /// <param name="positionY">
        /// The position y.
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        public string[,] DetonateMine5(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = this.DetonateMine4(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX - 2, positionY - 2);
            this.Explode(detonateMatrix, positionX + 2, positionY - 2);
            this.Explode(detonateMatrix, positionX - 2, positionY + 2);
            this.Explode(detonateMatrix, positionX + 2, positionY + 2);
            return detonateMatrix;
        }

        /// <summary>
        /// DIsplays the battlefield
        /// </summary>
        public void DisplayPlayground()
        {
            // top side numbers
            Console.Write("   ");
            for (int i = 0; i < this.fieldSize; i++)
            {
                Console.Write(" " + i.ToString() + "  ");
            }

            Console.WriteLine();

            // top side line under numbers
            Console.Write("    ");
            for (int i = 0; i < 4 * this.fieldSize - 3; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < this.fieldSize; i++)
            {
                // left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < this.fieldSize; j++)
                {
                    Console.Write(" " + this.playground[i, j]);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Gets number of mines by random principe
        /// </summary>
        /// <param name="random">
        /// random generated number
        /// </param>
        /// <returns>
        /// random <see cref="int"/>.
        /// </returns>
        public int GetNumberOfMines(Random random)
        {
            int downLimitNumber = Convert.ToInt32(0.15 * this.fieldSize * this.fieldSize);
            int upperLimitNumber = Convert.ToInt32(0.30 * this.fieldSize * this.fieldSize);
            int numberOfMines = random.Next(downLimitNumber, upperLimitNumber);
            return numberOfMines;
        }

        /// <summary>
        /// Initializes the mines on the field
        /// </summary>
        /// <param name="randomGenerator">
        /// The random generator.
        /// </param>
        /// <param name="numberOfMines">
        /// The number of mines.
        /// </param>
        /// <returns>
        /// Initialized mines <see cref="string[,]"/>.
        /// </returns>
        public string[,] InitMines(Random randomGenerator, int numberOfMines)
        {
            string[,] minesPlayground = this.InitializationEmptyPlayground(this.fieldSize);
            int countPutMines = 0;
            do
            {
                int coordinateX = randomGenerator.Next(0, this.fieldSize);
                int coordinateY = randomGenerator.Next(0, this.fieldSize);
                if (minesPlayground[coordinateX, coordinateY] == " - ")
                {
                    countPutMines++;
                    minesPlayground[coordinateX, coordinateY] = " " + randomGenerator.Next(1, 6) + " ";
                }
            }
            while (countPutMines < numberOfMines);
            return minesPlayground;
        }

        /// <summary>
        /// Initializes empty (new) playground
        /// </summary>
        /// <param name="size">
        /// The size 
        /// </param>
        /// <returns>
        /// The <see cref="string[,]"/>.
        /// </returns>
        public string[,] InitializationEmptyPlayground(int size)
        {
            var matrix = new string[size, size];
            for (int row = 0; row < this.fieldSize; row++)
            {
                for (int col = 0; col < this.fieldSize; col++)
                {
                    matrix[row, col] = " - ";
                }
            }

            return matrix;
        }

        /// <summary>
        /// Initializes the mines on the playground
        /// </summary>
        /// <returns>
        /// The number of mines<see cref="int"/>.
        /// </returns>
        public int InitializationPlaygroundMines()
        {
            var randomGenerator = new Random();
            int numberOfMines = this.GetNumberOfMines(randomGenerator);
            this.Playground = this.InitMines(randomGenerator, numberOfMines);
            return numberOfMines;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Marks current battlefield 
        ///  coordinate as exploded
        /// </summary>
        /// <param name="currentPlayground">
        /// The current playground.
        /// </param>
        /// <param name="positionX">
        /// The position x.
        /// </param>
        /// <param name="positionY">
        /// The position y.
        /// </param>
        private void Explode(string[,] currentPlayground, int positionX, int positionY)
        {
            if (this.IsValidCoordinate(positionX) && this.IsValidCoordinate(positionY))
            {
                currentPlayground[positionX, positionY] = EXPLOSION_MARK;
            }
        }

        /// <summary>
        /// The is valid coordinate.
        /// </summary>
        /// <param name="point">
        /// The point.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValidCoordinate(int point)
        {
            bool isInPlayground = point >= 0 && point < this.fieldSize;
            return isInPlayground;
        }

        #endregion
    }
}