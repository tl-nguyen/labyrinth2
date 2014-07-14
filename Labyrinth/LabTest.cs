namespace Labyrinth
{
    // smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    public class LabTest
    {
        static void Main()
        {
            GameEngine game = new GameEngine(
                      LabyrinthFactory.GetRendererInstance(LabyrinthFactory.GetLanguageStringsInstance()),
                      LabyrinthFactory.GetUserInputInstance());

            game.Run();
        }
    }
}
