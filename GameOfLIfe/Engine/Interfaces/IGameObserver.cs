namespace Engine.Interfaces
{
    public interface IGameObserver
    {
        void Update(IEnumerable<ICell> cells, int step);
    }
}
