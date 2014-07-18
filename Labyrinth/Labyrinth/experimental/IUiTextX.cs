namespace Labyrinth.Labyrinth.experimental
{
    interface IUiTextX : IRenderableX
    {
        void SetText(string key, string[] args);
        void SetText(string key);
        void Clear();
    }
}
