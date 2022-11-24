using GameOfLIfe.Interfaces;

namespace GameOfLIfe.Implementations
{
    public class Cell : ICell
    {
        public ICellState CurrentState { get; set; } = AliveConditionFactory.GetCondition("Dead");

        public Guid Guid { get; private set; }

        public Cell()
        {
            Guid = Guid.NewGuid();
        }
    }
}
