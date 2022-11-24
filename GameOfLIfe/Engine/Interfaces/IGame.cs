namespace Engine.Interfaces
{
    public interface IGame
    {
        void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer, IEnder ender);

        void Start();
    }
}
