using Engine.Interfaces;

namespace Engine.Implementations
{
    public class AliveCondition : ICellState
    {
        private struct AliveConditionSnapshot : ICellStateSnapshot
        {
            public string Name { get; set; }
            public string State { get; set; }
            public ICellState Originator { get; set; }

            public void RestoreState()
            {
                if (Originator is AliveCondition aliveCondition)
                {
                    aliveCondition.State = State;
                }
            }
        }

        public string State { get; set; }

        public AliveCondition(string state)
        {
            State = state;
        }

        public ICellStateSnapshot CreateSnapshot()
        {
            return new AliveConditionSnapshot()
            {
                Originator = this,
                State = State
            };
        }
    }
}
