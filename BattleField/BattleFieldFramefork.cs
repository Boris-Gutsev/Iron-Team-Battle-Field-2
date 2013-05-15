using System;

namespace BattleField
{
   public class BattleFieldFramefork
   {
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
                if (value <= 0) // TODO
                {
                    throw new ArgumentException("Fieldsize cannot be negative or zero");
                }

                this.fieldSize = value;
            }
        }

      #endregion

      public void InitField()
        {
         for (int i = 0; i < fieldSize; i++)
         {
            for (int j = 0; j < fieldSize; j++)
            {
               this.Positions[i, j] = " - ";
            }
         }
      }

      public void DisplayField()
      {
         //top side numbers
         Console.Write("   ");
         for (int i = 0; i < fieldSize; i++)
         {
            Console.Write(" " + i.ToString() + "  ");
         }
         Console.WriteLine("");

         Console.Write("    ");
         for (int i = 0; i < 4 * fieldSize - 3; i++)
         {
            Console.Write("-");
         }
         Console.WriteLine("");
         //top side numbers


         Console.WriteLine("");

         for (int i = 0; i < fieldSize; i++)
         {
            //left side numbers
            Console.Write(i.ToString() + "|");
            for (int j = 0; j < fieldSize; j++)
            {
               Console.Write(" " + this.positions[i, j].ToString());
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");
         }
      }
      public void InitMines()
      {//tuka ne sym siguren kakvo tochno pravq ama pyk raboti
         int minesDownLimit = Convert.ToInt32(0.15 * fieldSize * fieldSize);
         int minesUpperLimit = Convert.ToInt32(0.30 * fieldSize * fieldSize);
         int tempMineXCoordinate;
         int tempMineYCoordinate;
         bool flag = true;
         Random rnd = new Random();

         int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));
         int[,] minesPositions =
             
             new int[minesCount, minesCount];
         Console.WriteLine("mines count is: " + minesCount);

         for (int i = 0; i < minesCount; i++)
         {
            do {
                //tuka cikyla se vyrti dokato flag ne e false
                //s do-while raboti po dobre
               tempMineXCoordinate = 
                   Convert.ToInt32(rnd.Next(0, fieldSize - 1));
               tempMineYCoordinate = 
                   Convert.ToInt32(rnd.Next(0, fieldSize - 1));
               if (this.positions[tempMineXCoordinate, tempMineYCoordinate] == " - ")
                   this.positions[tempMineXCoordinate, tempMineYCoordinate] = 
                      " " + Convert.ToString(rnd.Next(1, 6) + " ");
               else
                  flag = false;
            } while (flag);
         }
      }

      //tuka sa mogyshtite metodi za gyrmejite

      public void DetonateMine1(int XCoord, int YCoord)
      {
         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 1, YCoord - 1] = " X ";
         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 1, YCoord + 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 1, YCoord - 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 1, YCoord + 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
      }

      public void DetonateMine2(int XCoord, int YCoord)
      {
         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 1, YCoord - 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord, YCoord - 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 1, YCoord - 1] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 1, YCoord] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 1, YCoord] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 1, YCoord + 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord, YCoord + 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 1, YCoord + 1] = " X ";
      }

      public void DetonateMine3(int XCoord, int YCoord)
      {
         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 2, YCoord] = " X ";
         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 1, YCoord] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 1, YCoord] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 2, YCoord] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 1, YCoord - 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 1, YCoord + 1] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 1, YCoord + 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 1, YCoord - 1] = " X ";

         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord, YCoord - 2] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord, YCoord - 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord, YCoord + 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord, YCoord + 2] = " X ";
      }

      public void DetonateMine4(int XCoord, int YCoord)
      {
         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 1, YCoord - 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord, YCoord - 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 1, YCoord - 1] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 1, YCoord] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 1, YCoord] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 1, YCoord + 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord, YCoord + 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 1, YCoord + 1] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord - 1, YCoord + 2] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord, YCoord + 2] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord + 1, YCoord + 2] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord - 1, YCoord - 2] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord, YCoord - 2] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord + 1, YCoord - 2] = " X ";

         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 2, YCoord - 1] = " X ";
         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 2, YCoord] = " X ";
         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 2, YCoord + 1] = " X ";

         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 2, YCoord - 1] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 2, YCoord] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 2, YCoord + 1] = " X ";
      }

      public void GrymniPetaBomba(int XCoord, int YCoord)
      {
         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 1, YCoord - 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord, YCoord - 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 1, YCoord - 1] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 1, YCoord] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord, YCoord] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 1, YCoord] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 1, YCoord + 1] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord, YCoord + 1] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 1, YCoord + 1] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord - 1, YCoord + 2] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord, YCoord + 2] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord + 1, YCoord + 2] = " X ";

         if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord - 1, YCoord - 2] = " X ";
         if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord, YCoord - 2] = " X ";
         if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord + 1, YCoord - 2] = " X ";

         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord - 2, YCoord - 1] = " X ";
         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord - 2, YCoord] = " X ";
         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord - 2, YCoord + 1] = " X ";

         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
             this.positions[XCoord + 2, YCoord - 1] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
             this.positions[XCoord + 2, YCoord] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
             this.positions[XCoord + 2, YCoord + 1] = " X ";

         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord - 2, YCoord - 2] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
             this.positions[XCoord + 2, YCoord - 2] = " X ";
         if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord - 2, YCoord + 2] = " X ";
         if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
             this.positions[XCoord + 2, YCoord + 2] = " X ";
      }


       //tuka se izbira kva bomba da grymne
      public void DetonateMine(int XCoord, int YCoord)
      {
          switch (Convert.ToInt32(this.positions[XCoord, YCoord]))
         {
            case 1: this.DetonateMine1(XCoord, YCoord);
               break;
            case 2: this.DetonateMine2(XCoord, YCoord);
               break;
            case 3: this.DetonateMine3(XCoord, YCoord);
               break;
            case 4: this.DetonateMine4(XCoord, YCoord);
               break;
            case 5: this.GrymniPetaBomba(XCoord, YCoord);
               break;
         }
      }

      public int PrebroiOstavashtiteMinichki()
      {
         int count = 0;

         for (int i = 0; i < fieldSize; i++)
         {
            for (int j = 0; i < fieldSize; i++)
            {
                if ((this.positions[i, j] != " X ") && (this.positions[i, j] != " - "))
                  count++;
            }
         }

         return count;
      }
   }
}