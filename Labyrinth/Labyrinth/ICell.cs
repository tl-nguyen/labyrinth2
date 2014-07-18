namespace Labyrinth
{
    public interface ICell
    {
        int Row { get; set; }
        int Col { get; set; }
        CellState CellValue { get; set; }
        bool IsEmpty();
    }
}
