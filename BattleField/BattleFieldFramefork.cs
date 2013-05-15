using System;

namespace BattleField
{
   public class BattleFieldFramefork
   {
      private const string EXPLOSION_MARK = " X ";

      private int fieldSize;
      private int detonatedMines;
      private string[,] positions;

      public BattleFieldFramefork(int fieldSize)
      {
          this.FieldSize = fieldSize;
          this.Positions = new string[this.FieldSize, this.FieldSize];
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

        public string[,] Positions
        {
            get
            {
                return this.positions;
            }

            private set
            {
                this.positions = value;
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
                if (value <= 0) 
                {
                    throw new ArgumentException("Fieldsize cannot be negative or zero");
                }

                this.fieldSize = value;
            }
        }

      #endregion

      public void InitField()
        {
         for (int row = 0; row < this.fieldSize; row++)
         {
            for (int col = 0; col < this.fieldSize; col++)
            {
               this.Positions[row, col] = " - ";
            }
         }
      }

      public void DisplayField()
      {
         // top side numbers
         Console.Write("   ");
         for (int i = 0; i < this.fieldSize; i++)
         {
            Console.Write(" " + i.ToString() + "  ");
         }
         Console.WriteLine(string.Empty);

         Console.Write("    ");
         for (int i = 0; i < 4 * this.fieldSize - 3; i++)
         {
            Console.Write("-");
         }

         Console.WriteLine(string.Empty);
        
          // top side numbers
         Console.WriteLine(string.Empty);

         for (int i = 0; i < this.fieldSize; i++)
         {
            // left side numbers
            Console.Write(i.ToString() + "|");
            for (int j = 0; j < this.fieldSize; j++)
            {
               Console.Write(" " + this.positions[i, j].ToString());
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
         }
      }

      public void InitMines()
      {
         int minesDownLimit = Convert.ToInt32(0.15 * this.fieldSize * this.fieldSize);
         int minesUpperLimit = Convert.ToInt32(0.30 * this.fieldSize * this.fieldSize);
         int tempMineXCoordinate;
         int tempMineYCoordinate;
         bool flag = true;
         Random rand = new Random();

         int minesCount = Convert.ToInt32(rand.Next(minesDownLimit, minesUpperLimit));
         int[,] minesPositions = new int[minesCount, minesCount];
         Console.WriteLine("mines count is: " + minesCount);

         for (int i = 0; i < minesCount; i++)
         {
             do
             {
                 tempMineXCoordinate = Convert.ToInt32(rand.Next(0, this.fieldSize - 1));
                 tempMineYCoordinate = Convert.ToInt32(rand.Next(0, this.fieldSize - 1));
                 if (this.positions[tempMineXCoordinate, tempMineYCoordinate] == " - ")
                 {
                     this.positions[tempMineXCoordinate, tempMineYCoordinate] = " "
                                                                                + Convert.ToString(rand.Next(1, 6) + " ");
                 }
                 else
                 {
                     flag = false;
                 }
             }
             while (flag);
         }
      }

      public void DetonateMine(int positionX, int positionY)
      {
          byte power = Convert.ToByte(this.positions[positionX, positionY]);

          // if the power is > 1 explosions continue 
          // till they match condition for example power == 2/3/4

          // exploding cell when power is 1
          this.Explode(positionX, positionY);
          this.Explode(positionX - 1, positionY - 1);
          this.Explode(positionX - 1, positionY + 1);
          this.Explode(positionX + 1, positionY - 1);
          this.Explode(positionX + 1, positionY + 1);

          if (power == 1)
          {
              return;
          }

          // exploding cell when power is 2
          this.Explode(positionX, positionY - 1);
          this.Explode(positionX - 1, positionY);
          this.Explode(positionX + 1, positionY);
          this.Explode(positionX, positionY + 1);

          if (power == 2)
          {
              return;
          }

          // exploding cell when power is 3
          this.Explode(positionX - 2, positionY);
          this.Explode(positionX + 2, positionY);
          this.Explode(positionX, positionY - 2);
          this.Explode(positionX, positionY + 2);

          if (power == 3)
          {
              return;
          }

          // exploding cell when power is 4
          this.Explode(positionX - 1, positionY + 2);
          this.Explode(positionX + 1, positionY + 2);
          this.Explode(positionX - 1, positionY - 2);
          this.Explode(positionX + 1, positionY - 2);
          this.Explode(positionX - 2, positionY - 1);
          this.Explode(positionX - 2, positionY + 1);
          this.Explode(positionX + 2, positionY - 1);
          this.Explode(positionX + 2, positionY + 1);

          if (power == 4)
          {
              return;
          }

          // exploding cell when power is 5
          this.Explode(positionX - 2, positionY - 2);
          this.Explode(positionX + 2, positionY - 2);
          this.Explode(positionX - 2, positionY + 2);
          this.Explode(positionX + 2, positionY + 2);
      }

      public int CountRemainingMines()
      {
         int count = 0;

         for (int row = 0; row < this.fieldSize; row++)
         {
            for (int col = 0; col < this.fieldSize; col++)
            {
                if ((this.positions[row, col] != " X ") && (this.positions[row, col] != " - "))
                {
                    count++;
                }
            }
         }

         return count;
      }

      private bool IsValidCoordinate(int point)
      {
          return point >= 0 && point < this.fieldSize;
      }

      private void Explode(int positionX, int positionY)
      {
          if (this.IsValidCoordinate(positionX) && this.IsValidCoordinate(positionY))
          {
              this.positions[positionX, positionY] = EXPLOSION_MARK;
          }
      }
   }
}