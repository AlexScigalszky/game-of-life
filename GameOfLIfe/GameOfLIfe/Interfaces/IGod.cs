namespace GameOfLIfe.Interfaces
{
    public interface IGod
    {
        bool IsAlive(ICell cell, IEnumerable<ICell> neigthbords);
        ICellState GetRandomCellState();
    }
}
