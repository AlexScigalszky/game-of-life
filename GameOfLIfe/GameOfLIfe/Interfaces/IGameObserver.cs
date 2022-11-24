namespace GameOfLIfe.Interfaces
{
    public interface IGameObserver
    {
        void Update(IEnumerable<ICell> cells);
    }
}
