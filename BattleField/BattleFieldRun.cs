using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    class BattleFieldRun
    {
        public static void Main(string[] args)
        {
            int fieldSize;
           string tempFieldSize;
           Console.WriteLine("Welcome to the Battle Field game");
           do
           {
              Console.Write("Enter legal size of board: ");
              tempFieldSize = Console.ReadLine();
           } while ((!Int32.TryParse(tempFieldSize, out fieldSize)) || (fieldSize < 0) || (fieldSize > 11));

           BattleFieldFramefork bf = new BattleFieldFramefork(fieldSize);
           bf.InitField();
           bf.InitMines();
           bf.DisplayField();

           string coordinates;
           int XCoord, YCoord;

           do
           {
              do
              {
                 Console.Write("Enter coordinates: ");
                 coordinates = Console.ReadLine();
                 XCoord = Convert.ToInt32(coordinates.Substring(0, 1));
                 YCoord = Convert.ToInt32(coordinates.Substring(2));

                 if ((XCoord < 0) || (YCoord > fieldSize - 1) || (bf.Pozicii[XCoord, YCoord] == " - "))
                    Console.WriteLine("Invalid Move");
              } while ((XCoord < 0) || (YCoord > fieldSize - 1) || (bf.Pozicii[XCoord, YCoord] == " - "));

              bf.DetonateMine(XCoord, YCoord);
              bf.DisplayField();
              bf.DetonatedMines++;
           } while (bf.PrebroiOstavashtiteMinichki() != 0);

           Console.WriteLine("Game Over. Detonated Mines: " + bf.DetonatedMines);
           Console.ReadKey();
        }

    }
}
