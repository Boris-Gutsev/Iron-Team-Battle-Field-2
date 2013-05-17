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

            int numberOfMines = battleField.InitializationPlaygroundMines();
            Console.WriteLine("Mines count: {0}\n", numberOfMines);
            battleField.DisplayPlayground();
            
            do
            {
                FieldCoordinates fieldCoordinates = InputFieldCoordinates(battleField);

                battleField.Playground = battleField.DetonateMine(battleField.Playground, fieldCoordinates.Row, fieldCoordinates.Col);
                battleField.DisplayPlayground();
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
                Console.Write("Enter coordinates: ");

                string getMinePosition = Console.ReadLine();
                string[] coordinates = getMinePosition.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                fieldCoordinates.Row = int.Parse(coordinates[0]);
                fieldCoordinates.Col = int.Parse(coordinates[1]);

                isInField = (fieldCoordinates.Row >= MIN_BORDER) && (fieldCoordinates.Row <= battleField.FieldSize -1) &&
                            (fieldCoordinates.Col >= MIN_BORDER) && (fieldCoordinates.Col <= battleField.FieldSize - 1);
                if (isInField)
                {
                    isEmptyCell = (battleField.Playground[fieldCoordinates.Row, fieldCoordinates.Col] == EMPTY_CELL);
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

                isInputSizeParseCorrect = int.TryParse(fieldSizeStr, out fieldSize);
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
