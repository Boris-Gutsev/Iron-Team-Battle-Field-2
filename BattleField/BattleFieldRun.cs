using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleField
{
    class BattleFieldRun
    {
        public static readonly int MIN_FIELD_SIZE = 0;
        public static readonly int MAX_FIELD_SIZE = 11;

        public static readonly int MIN_BORDER = 0;
        public static readonly string EMPTY_CELL = " - ";

        public static void Main(string[] args)
        {
            int fieldSize = InputFielsSize();

            BattleFieldFramefork bf = new BattleFieldFramefork(fieldSize);
            bf.InitField();
            bf.InitMines();
            bf.DisplayField();

           
            int coordX = 0;
            int coordY = 0;

            do
            {
                bool isInField = true;
                bool isEmptyCell = false;
                do
                {
                    //TODO: do try parse, correct parse
                    Console.Write("Enter coordinates: ");
                    string coordinates = Console.ReadLine();
                    coordX = Convert.ToInt32(coordinates.Substring(0, 1));
                    coordY = Convert.ToInt32(coordinates.Substring(2));

                    isInField = (coordX >= MIN_BORDER) && (coordX <= fieldSize - 1) && 
                        (coordY >= MIN_BORDER) && (coordY <= fieldSize - 1);
                    if (isInField)
                    {
                        isEmptyCell = (bf.Pozicii[coordX, coordY] == EMPTY_CELL);
                    }
                   
                    if (!isInField || isEmptyCell)
                    {
                        Console.WriteLine("Invalid Move");
                    }
                }
                while (!isInField || isEmptyCell);

                bf.DetonateMine(coordX, coordY);
                bf.DisplayField();
                bf.DetonatedMines++;
            }
            while (bf.PrebroiOstavashtiteMinichki() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + bf.DetonatedMines);
            Console.ReadKey();
        }
  
        private static int InputFielsSize()
        {
            int fieldSize;
            string fieldSizeStr;
            bool isInputSizeParseCorrect = false;
            bool isFieldSizeCorrect = false;
            Console.WriteLine("Welcome to the Battle Field game");
            do
            {
                Console.Write("Enter legal size of board: ");
                fieldSizeStr = Console.ReadLine();
                isInputSizeParseCorrect = Int32.TryParse(fieldSizeStr, out fieldSize);
                if (isInputSizeParseCorrect)
                {
                    isFieldSizeCorrect = (fieldSize > MIN_FIELD_SIZE) && (fieldSize < MAX_FIELD_SIZE);
                }
            }
            while (!isFieldSizeCorrect);
            return fieldSize;
        }
    }
}
