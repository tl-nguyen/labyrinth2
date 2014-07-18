namespace Labyrinth.Labyrinth.experimental
{
    interface IUiTextX : IRenderableX
    {
        void SetText(string input, string[] args);
        void SetText(string input, bool isKey);
        void SetText(string input);
        void Clear();
    }
}
