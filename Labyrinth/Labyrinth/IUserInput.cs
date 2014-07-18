namespace Labyrinth
{
    using Commons;

    public interface IUserInput
    {
        Command GetInput();
        string GetPlayerName();

    }
}
