namespace Labyrinth
{
    public interface IUserInput
    {
        Command GetInput();
        string GetPlayerName();

        bool TryMove(Command input, ILabyrinth labyrinth);
    }
}
