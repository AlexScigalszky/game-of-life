namespace Engine.Interfaces
{
    public interface IGameBuilder
    {
        void Reset();
        void BuildLand();
        void BuildGod();
        void BuildObserver();
        void BuildEnder();
        IGame GetGame();
    }
}
