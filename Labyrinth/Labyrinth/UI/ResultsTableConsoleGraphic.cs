// ********************************
// <copyright file="ResultsTableConsoleGraphic.cs" company="Telerik Academy">
// Copyright (c) 2014 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Labyrinth.UI
{
    using System.Text;
    using Commons;
    using Entities.Contracts;
    using Renderer.Contracts;

    public class ResultsTableConsoleGraphic : EntityConsoleGraphic
    {
        private const int WIDTH = 35;
        private const string HORIZONTAL_LINE = "|----------------------------------|";
        private const string TITLE = "|         Top Results Table        |";
        private const string TABLE_IS_EMPTY = "|     The scoreboard is empty.     |";

        private IResultsTable table;

        public ResultsTableConsoleGraphic(IResultsTable table, IntPoint coords, IRenderer renderer)
            : base(table, coords, renderer)
        {
            this.table = table;
            this.Graphic = this.GenerateStringGraphic();
        }

        override protected string[] GenerateStringGraphic()
        {
            string[] results = this.table.Table.GetTopResultsStrings();
            int resultsCount = results.Length;
            bool tableIsEmpty = resultsCount == 0;

            int extraLines = 4;
            if(tableIsEmpty)
            {
                extraLines++; //one more line for "table is empty" message
            }

            string[] graphic = new string[resultsCount + extraLines];
            int currentLine = 0;

            graphic[currentLine] = ResultsTableConsoleGraphic.HORIZONTAL_LINE;
            currentLine++;
            graphic[currentLine] = ResultsTableConsoleGraphic.TITLE;
            currentLine++;
            graphic[currentLine] = ResultsTableConsoleGraphic.HORIZONTAL_LINE;
            currentLine++;

            if (tableIsEmpty)
            {
                graphic[currentLine] = ResultsTableConsoleGraphic.TABLE_IS_EMPTY;
                currentLine++;
            }
            else
            {
                for (int i = 0; i < resultsCount; i++)
                {
                    graphic[currentLine] = string.Format("| {0}. {1}", i + 1, results[i]);
                    currentLine++;
                }
            }

            graphic[currentLine] = ResultsTableConsoleGraphic.HORIZONTAL_LINE;

            return graphic;
        }
    }
}
