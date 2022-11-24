using Engine.Interfaces;

namespace Engine.Implementations
{
    public class AliveCondition : ICellState
    {
        public string State { get; private set; }

        public AliveCondition(string state)
        {
            State = state;
        }
    }
}
