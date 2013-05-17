using System;

namespace BattleField
{
    public class BattleFieldFramefork
    {
        private const string EXPLOSION_MARK = " X ";

        private int fieldSize;
        private int detonatedMines;
        private string[,] playground;

        public BattleFieldFramefork(int fieldSize)
        {
            this.FieldSize = fieldSize;
            this.Playground = InitializationEmptyPlayground(this.FieldSize);
            this.DetonatedMines = 0;
        }

        #region properties
        
        public int DetonatedMines
        {
            get
            {
                return this.detonatedMines;
            }
            set
            {
                this.detonatedMines = value;
            }
        }
        
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
        
        public int FieldSize
        {
            get
            {
                return this.fieldSize;
            }
            private set
            {
                if (value <= 0) // TODO
                {
                    throw new ArgumentException("Fieldsize cannot be negative or zero");
                }
                
                this.fieldSize = value;
            }
        }
        
        #endregion
        
        public string[,] InitializationEmptyPlayground(int size)
        {
            string[,] matrix = new string[size, size];
            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    matrix[row, col] = " - ";
                }
            }
            return matrix;
        }
        
        public void DisplayPlaygraund()
        {
            //top side numbers
            Console.Write("   ");
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(" " + i.ToString() + "  ");
            }
            Console.WriteLine("");
            
            //top side line under numbers
            Console.Write("    ");
            for (int i = 0; i < 4 * fieldSize - 3; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine();
            
            for (int i = 0; i < fieldSize; i++)
            {
                //left side numbers
                Console.Write(i.ToString() + "|");
                for (int j = 0; j < fieldSize; j++)
                {
                    Console.Write(" " + this.playground[i, j].ToString());
                }
                Console.WriteLine(); 
                Console.WriteLine(); 
                Console.WriteLine();
            }
        }

        public int InitializationPlaygroundMines()
        {
            Random randomGenerator = new Random();
            int numberOfMines = GetNumberOfMines(randomGenerator);         
            this.Playground = InitMines(randomGenerator, numberOfMines);
            return numberOfMines;
        }

        public int GetNumberOfMines(Random random)
        {
            int downLimitNumber = Convert.ToInt32(0.15 * fieldSize * fieldSize);
            int upperLimitNumber = Convert.ToInt32(0.30 * fieldSize * fieldSize);
            int numberOfMines = random.Next(downLimitNumber, upperLimitNumber);
            return numberOfMines;
        }

        public string[,] InitMines(Random randomGenerator, int numberOfMines)
        { 
            string[,] minesPlayground = InitializationEmptyPlayground(fieldSize);                                  
            int countPutMines = 0;
            do
            {
                int coordinateX = randomGenerator.Next(0, fieldSize);
                int coordinateY = randomGenerator.Next(0, fieldSize);
                if (minesPlayground[coordinateX, coordinateY] == " - ")
                {
                    countPutMines++;
                    minesPlayground[coordinateX, coordinateY] = " " + randomGenerator.Next(1, 6) + " ";
                }
            }
            while (countPutMines<numberOfMines);
            return minesPlayground;
        }       

        public string[,] DetonateMine1(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = currentPlayground;
            this.Explode(detonateMatrix,positionX, positionY);
            this.Explode(detonateMatrix,positionX - 1, positionY - 1);
            this.Explode(detonateMatrix,positionX - 1, positionY + 1);
            this.Explode(detonateMatrix,positionX + 1, positionY - 1);
            this.Explode(detonateMatrix,positionX + 1, positionY + 1);
            return detonateMatrix;
        }

        public string[,] DetonateMine2(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = DetonateMine1(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX, positionY - 1);
            this.Explode(detonateMatrix, positionX - 1, positionY);
            this.Explode(detonateMatrix, positionX + 1, positionY);
            this.Explode(detonateMatrix, positionX, positionY + 1);          
            return detonateMatrix;
        }

        public string[,] DetonateMine3(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = DetonateMine2(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX - 2, positionY);
            this.Explode(detonateMatrix, positionX + 2, positionY);
            this.Explode(detonateMatrix, positionX, positionY - 2);
            this.Explode(detonateMatrix, positionX, positionY + 2);          
            return detonateMatrix;
        }

        public string[,] DetonateMine4(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = DetonateMine3(currentPlayground, positionX, positionY);
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

        public string[,] DetonateMine5(string[,] currentPlayground, int positionX, int positionY)
        {
            string[,] detonateMatrix = DetonateMine4(currentPlayground, positionX, positionY);
            this.Explode(detonateMatrix, positionX - 2, positionY - 2);
            this.Explode(detonateMatrix, positionX + 2, positionY - 2);
            this.Explode(detonateMatrix, positionX - 2, positionY + 2);
            this.Explode(detonateMatrix, positionX + 2, positionY + 2);          
            return detonateMatrix;
        }
        
        public string[,] DetonateMine(string[,] currentPlaygraund, int XCoord, int YCoord)
        {
            int minesType = Convert.ToInt32(currentPlaygraund[XCoord, YCoord]);
            string[,] detonatePlaygraund = currentPlaygraund;
            switch (minesType)
            {
                case 1:
                    detonatePlaygraund = this.DetonateMine1(currentPlaygraund,XCoord, YCoord);
                    break;
                case 2:
                    detonatePlaygraund = this.DetonateMine2(currentPlaygraund, XCoord, YCoord);
                    break;
                case 3:
                    detonatePlaygraund = this.DetonateMine3(currentPlaygraund, XCoord, YCoord);
                    break;
                case 4:
                    detonatePlaygraund = this.DetonateMine4(currentPlaygraund, XCoord, YCoord);
                    break;
                case 5:
                    detonatePlaygraund = this.DetonateMine5(currentPlaygraund,XCoord, YCoord);
                    break;
                default:
                    throw new ArgumentException("Mines type are 1 - 5. You try open " + minesType);
            }
            return detonatePlaygraund;
        }
        
        public int PrebroiOstavashtiteMinichki()
        {
            int count = 0;
            
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; i < fieldSize; i++)
                {
                    if ((this.playground[i, j] != " X ") && (this.playground[i, j] != " - "))
                        count++;
                }
            }
            
            return count;
        }

        private bool IsValidCoordinate(int point)
        {
            bool isInPlayground = point >= 0 && point < this.fieldSize;
            return isInPlayground;
        }

        private void Explode(string[,] currentPlayground, int positionX, int positionY)
        {
            if (this.IsValidCoordinate(positionX) && this.IsValidCoordinate(positionY))
            {
                currentPlayground[positionX, positionY] = EXPLOSION_MARK;
            }
        }
    }
}