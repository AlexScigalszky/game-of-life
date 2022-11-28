namespace Engine.Interfaces
{
    public interface IGameSnapshot
    {
        public IGame Originator { get; set; }
        public string Name { get; set; }
        public IGodSnapshot? God { get; set; }
        public IGameLandSnapshot? Land { get; set; }
        public int Step { get; set; }
        void RestoreState();
    }
}
