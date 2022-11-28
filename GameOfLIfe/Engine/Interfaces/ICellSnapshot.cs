namespace Engine.Interfaces
{
    public interface ICellSnapshot
    {
        public ICell Originator { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public ICellStateSnapshot CurrentState { get; set; }
        void RestoreState();
    }
}
