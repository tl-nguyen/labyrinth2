namespace Labyrinth
{
    // smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    public class GameStart
    {
        private const int GAME_SCREEN_COLS = 80;
        private const int GAME_SCREEN_ROWS = 30;

        public static void Main()
        {
            GameEngine game = new GameEngine(GAME_SCREEN_COLS, GAME_SCREEN_ROWS);
            game.Run();
        }
    }
}