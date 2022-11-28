namespace Engine.Interfaces
{
    public interface IGameObserver
    {
<<<<<<< HEAD
        void Update(IGame game);
=======
        void Update(IEnumerable<ICell> cells, int step);
>>>>>>> main
    }
}
