using Engine.Interfaces;

namespace Engine.Implementations
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
