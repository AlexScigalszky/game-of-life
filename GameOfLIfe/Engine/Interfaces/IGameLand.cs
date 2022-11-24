namespace Engine.Interfaces
{
    public interface IGameLand<T> where T : class, ICell
    {
        public int AvaliableSpaces { get; }
        IEnumerable<T> Occupants { get; }
        void OccupyNextAvaliableSpace(T cell);
        IEnumerable<T> GetNeigbords(T occupant);
        IGameLand<T> Clone();
    }
}
