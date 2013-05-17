// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BattleFieldRun.cs" company="Telerik">
//   
// </copyright>
// <summary>
//   The battle field run.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace BattleField
{
    using System;

    /// <summary>
    /// The battle field run.
    /// </summary>
    internal class BattleFieldRun
    {
        #region constants

        /// <summary>
        ///  The minimum field size
        /// </summary>
        public static readonly int MIN_FIELD_SIZE = 0;

        /// <summary>
        /// The maximum field size
        /// </summary>
        public static readonly int MAX_FIELD_SIZE = 11;

        /// <summary>
        ///  border minimum
        /// </summary>
        public static readonly int MIN_BORDER = 0;

        /// <summary>
        ///  empty cell sign
        /// </summary>
        public static readonly string EMPTY_CELL = " - ";

        #endregion

        /// <summary>
        ///  The entry method
        /// </summary>
        public static void Main()
        {
            int fieldSize = InputFielsSize();

            BattleFieldFramework battleField = new BattleFieldFramework(fieldSize);

            int numberOfMines = battleField.InitializationPlaygroundMines();
            Console.WriteLine("Mines count: {0}\n", numberOfMines);
            battleField.DisplayPlayground();

            do
            {
                FieldCoordinates fieldCoordinates = InputFieldCoordinates(battleField);

                battleField.Playground = battleField.DetonateMine(
                    battleField.Playground, fieldCoordinates.Row, fieldCoordinates.Col);
                battleField.DisplayPlayground();
                battleField.DetonatedMines++;
            }
            while (battleField.CountRemainingMines() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + battleField.DetonatedMines);
            Console.ReadKey();
        }

        /// <summary>
        /// The input field coordinates.
        /// </summary>
        /// <param name="battleField">
        /// The battle field.
        /// </param>
        /// <returns>
        /// The <see cref="FieldCoordinates"/>.
        /// </returns>
        private static FieldCoordinates InputFieldCoordinates(BattleFieldFramework battleField)
        {
            FieldCoordinates fieldCoordinates = new FieldCoordinates();
            bool isInField = true;
            bool isEmptyCell = false;
            do
            {
                Console.Write("Enter coordinates: ");

                string getMinePosition = Console.ReadLine();
                if (getMinePosition != null)
                {
                    string[] coordinates = getMinePosition.Split(
                        new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    fieldCoordinates.Row = int.Parse(coordinates[0]);
                    fieldCoordinates.Col = int.Parse(coordinates[1]);
                }

                isInField = (fieldCoordinates.Row >= MIN_BORDER) && (fieldCoordinates.Row <= battleField.FieldSize - 1)
                            && (fieldCoordinates.Col >= MIN_BORDER)
                            && (fieldCoordinates.Col <= battleField.FieldSize - 1);
                if (isInField)
                {
                    isEmptyCell = battleField.Playground[fieldCoordinates.Row, fieldCoordinates.Col] == EMPTY_CELL;
                }

                if (!isInField || isEmptyCell)
                {
                    Console.WriteLine("Invalid Move");
                }
            }
            while (!isInField || isEmptyCell);
            return fieldCoordinates;
        }

        /// <summary>
        /// The field size input method
        /// </summary>
        /// <returns>
        /// field size in  <see cref="int"/>.
        /// </returns>
        private static int InputFielsSize()
        {
            int fieldSize;
            bool isFieldSizeCorrect = false;

            Console.WriteLine("Welcome to the Battle Field game");
            do
            {
                Console.Write("Enter legal size of board: ");
                string fieldSizeStr = Console.ReadLine();

                bool isInputSizeParseCorrect = int.TryParse(fieldSizeStr, out fieldSize);
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