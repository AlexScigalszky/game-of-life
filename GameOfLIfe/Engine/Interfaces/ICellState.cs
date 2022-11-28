namespace Engine.Interfaces
{
    public interface ICellState
    {
        public string State { get; }
        ICellStateSnapshot CreateSnapshot();
    }
}
