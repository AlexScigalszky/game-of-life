namespace Engine.Interfaces
{
    public interface ICellStateSnapshot
    {
        public ICellState Originator { get; set; }
        public string Name { get; set; }
        public string State { get; internal set; }
        void RestoreState();
    }
}
