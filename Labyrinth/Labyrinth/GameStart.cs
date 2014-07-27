namespace Labyrinth
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public class GameStart
    {
        private const int GameScreenCols = 80;
        private const int GameScreenRows = 30;

        /// <summary>
        /// Entry method of the program.
        /// </summary>
        public static void Main()
        {
            GameEngine game = new GameEngine(GameScreenCols, GameScreenRows);
            game.Run();
        }
    }
}