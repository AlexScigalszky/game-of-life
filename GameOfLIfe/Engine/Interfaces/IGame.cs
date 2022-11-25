namespace Engine.Interfaces
{
    public interface IGame
    {
        void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer);

        void Start();

        void Next();
    }
}
