namespace GameOfLIfe.Interfaces
{
    public interface ICell
    {
        ICellState CurrentState { get; set; }
        public Guid Guid { get; }
    }
}
