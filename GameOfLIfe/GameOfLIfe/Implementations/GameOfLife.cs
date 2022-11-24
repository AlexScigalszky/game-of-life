using GameOfLIfe.Interfaces;

namespace GameOfLIfe.Implementations
{
    public class GameOfLife : IGame
    {
        private bool _isPlaying = false;
        private IGod _god;
        private IGameObserver _observer;
        private IGameLand<ICell> _land;

        public void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer)
        {
            _land = land;
            _god = god;
            _observer = observer;
            for (var i = 0; i < _land.AvaliableSpaces; i++)
            {
                var cell = new Cell
                {
                    CurrentState = _god.GetRandomCellState(),
                };
                _land.OccupyNextAvaliableSpace(cell);
            }
            _isPlaying = false;

        }
        public void Start(Func<bool> shouldContinue)
        {
            _observer.Update(_land.Occupants);
            _isPlaying = true;

            while (_isPlaying)
            {

                var nextStates = CalculateNextStates();

                UpdateNewStates(nextStates);

                _observer.Update(_land.Occupants);

                _isPlaying = shouldContinue();
            }
        }

        private void UpdateNewStates(Dictionary<ICell, ICellState> nextStates)
        {
            foreach (var obj in nextStates)
            {
                obj.Key.CurrentState = obj.Value;
            }
        }

        private Dictionary<ICell, ICellState> CalculateNextStates()
        {
            var newStates = new Dictionary<ICell, ICellState>();

            foreach (var cell in _land.Occupants)
            {
                var neigbords = _land.GetNeigbords(cell);

                if (_god.IsAlive(cell, neigbords))
                {
                    newStates[cell] = AliveConditionFactory.GetCondition("Alive");
                }
                else
                {
                    newStates[cell] = AliveConditionFactory.GetCondition("Dead");
                }
            }

            return newStates;
        }

    }
}
