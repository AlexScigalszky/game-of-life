using GameOfLIfe.Interfaces;

namespace GameOfLIfe.Implementations
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
