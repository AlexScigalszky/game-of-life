namespace Engine.Interfaces
{
    public interface IGame
    {
        public int Step { get; set; }
        void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer);
        void Start();
        void Next();
        IGameSnapshot CreateSnapshot();
        IEnumerable<ICell> GetCells();
    }
}
