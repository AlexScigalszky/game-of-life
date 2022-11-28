namespace Engine.Interfaces
{
    public interface IGameLandSnapshot
    {
        public IGameLand<ICell> Originator { get; set; }
        public string Name { get; set; }
        public ICellSnapshot[] Grid { get; set; }
        public int NextAvailableSpace { get; set; }
        public int Width { get; set; }
        public int MaxAvailableSpace { get; set; }
        public Dictionary<Guid, int> Indexes { get; set; }
        void RestoreState();
    }
}
