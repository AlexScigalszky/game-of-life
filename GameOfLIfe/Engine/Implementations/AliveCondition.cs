using Engine.Interfaces;

namespace Engine.Implementations
{
    public class AliveCondition : ICellState
    {
        private static AliveCondition? _alive;
        private static AliveCondition? _dead;
        private static object _deadLock = new();

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

        /// <summary>
        /// Using double check and implement thread safe lock
        /// </summary>
        /// <returns></returns>
        public static AliveCondition GetDead()
        {
            if (_dead is null) // The first check
            {
                lock (_deadLock)
                {
                    if (_dead is null) // The second (double) check
                    {
                        _dead = new AliveCondition("Dead");
                    }
                }
            }

            return _dead;
        }
    }
}
