namespace GameOfLIfe.Interfaces
{
    public interface IGame
    {
        void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer);

        void Start(Func<bool> shouldContinue);
    }
}
