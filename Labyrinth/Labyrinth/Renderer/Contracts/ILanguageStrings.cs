namespace Labyrinth.Renderer.Contracts
{
    using Labyrinth.Commons;
    public interface ILanguageStrings
    {
        /// <summary>
        /// Returns the dialog string, corresponding to the given string key.
        /// </summary>
        string GetDialog(Dialog key);
    }
}