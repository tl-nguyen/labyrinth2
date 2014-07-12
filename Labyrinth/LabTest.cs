namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

	// smilih se nad vas kolegi, ne sym puskal obfuskatora, shtoto se zamislih, che i vie moze da imate
    public class LabTest
    {
        static void Main()
        {
            GameEngine game = new GameEngine(
                      LabyrinthFactory.GetRendererInstance(),
                      LabyrinthFactory.GetUserInputInstance());
            
            while (!game.hasEndedGame)
            {
                game.UpdateUserInput();
            }
        }
    }
}
