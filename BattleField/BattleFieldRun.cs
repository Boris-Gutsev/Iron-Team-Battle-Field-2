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

            BattleFieldFramefork battleField = new BattleFieldFramefork(fieldSize);
            battleField.InitField();
            battleField.InitMines();
            battleField.DisplayField();          
            
            do
            {
                FieldCoordinates fieldCoordinates = InputFieldCoordinates(battleField);

                battleField.DetonateMine(fieldCoordinates.row, fieldCoordinates.col);
                battleField.DisplayField();
                battleField.DetonatedMines++;
            }
            while (battleField.CountRemainingMines() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + battleField.DetonatedMines);
            Console.ReadKey();
        }

        private static FieldCoordinates InputFieldCoordinates(BattleFieldFramefork battleField)
        {
            FieldCoordinates fieldCoordinates = new FieldCoordinates();
            bool isInField = true;
            bool isEmptyCell = false;
            do
            {
                //TODO: do try parse, correct parse
                Console.Write("Enter coordinates: ");
                string coordinates = Console.ReadLine();
                fieldCoordinates.row = Convert.ToInt32(coordinates.Substring(0, 1));
                fieldCoordinates.col = Convert.ToInt32(coordinates.Substring(2));

                isInField = (fieldCoordinates.row >= MIN_BORDER) && (fieldCoordinates.row <= battleField.FieldSize -1) &&
                            (fieldCoordinates.col >= MIN_BORDER) && (fieldCoordinates.col <= battleField.FieldSize - 1);
                if (isInField)
                {
                    isEmptyCell = (battleField.Positions[fieldCoordinates.row, fieldCoordinates.col] == EMPTY_CELL);
                }
                     
                if (!isInField || isEmptyCell)
                {
                    Console.WriteLine("Invalid Move");
                }
            }
            while (!isInField || isEmptyCell);
            return fieldCoordinates;
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
