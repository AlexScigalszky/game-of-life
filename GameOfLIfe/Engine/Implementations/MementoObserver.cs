using Engine.Interfaces;

namespace Engine.Implementations
{
    public class MementoObserver : IGameObserver
    {
        private readonly Stack<IGameSnapshot> History = new();

        public void Update(IGame game)
        {
            History.Push(game.CreateSnapshot());
        }
    }
}
