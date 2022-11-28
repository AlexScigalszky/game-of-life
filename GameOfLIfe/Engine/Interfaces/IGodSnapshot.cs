namespace Engine.Interfaces
{
    public interface IGodSnapshot
    {
        public IGod Originator { get; set; }
        public string Name { get; set; }
        void RestoreState();
    }
}
