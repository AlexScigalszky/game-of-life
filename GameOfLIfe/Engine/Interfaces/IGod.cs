namespace Engine.Interfaces
{
    public interface IGod
    {
        ICellState GetNextCellState(ICell cell, IEnumerable<ICell> neigthbords);
        ICellState GetRandomCellState();
        IGodSnapshot CreateSnapshot();
    }
}
