using GameOfLIfe.Interfaces;

namespace GameOfLIfe.Implementations
{
    public class AliveCondition : ICellState
    {
        private static AliveCondition? _alive;
        private static AliveCondition? _dead;

        public string State { get; private set; }

        private AliveCondition(string state)
        {
            State = state;
        }

        public static AliveCondition GetAlive()
        {
            if (_alive == null)
            {
                _alive = new AliveCondition("Alive");
            }
            return _alive;
        }

        public static AliveCondition GetDead()
        {
            if (_dead == null)
            {
                _dead = new AliveCondition("Dead");
            }
            return _dead;
        }
    }
}
