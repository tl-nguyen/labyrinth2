namespace Labyrinth.Renderer.Contracts
{
    public interface ILanguageStrings
    {
        /// <summary>
        /// Returns the dialog string, corresponding to the given string key.
        /// </summary>
        string GetDialog(string key);
    }
}