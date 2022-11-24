using Engine.Interfaces;

namespace Engine.Implementations
{
    public class GameOfLife : IGame
    {
        private bool _isPlaying = false;
        private IGod? _god;
        private IGameObserver? _observer;
        private IGameLand<ICell>? _land;
        private IEnder? _ender;

        public void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer, IEnder ender)
        {
            _land = land;
            _god = god;
            _observer = observer;
            _ender = ender;
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
        public void Start()
        {
            var occupants = _land?.Occupants ?? Array.Empty<ICell>();
            _observer?.Update(occupants);
            _isPlaying = true;

            while (_isPlaying)
            {

                var nextStates = CalculateNextStates();

                UpdateNewStates(nextStates);

                _observer?.Update(occupants);

                _isPlaying = _ender?.ShouldContinue() ?? false;
            }
        }

        private void UpdateNewStates(Dictionary<ICell, ICellState?> nextStates)
        {
            foreach (var obj in nextStates)
            {
                if (obj.Value != null)
                {
                    obj.Key.CurrentState = obj.Value;
                }
            }
        }

        private Dictionary<ICell, ICellState?> CalculateNextStates()
        {
            var newStates = new Dictionary<ICell, ICellState?>();
            var occupants = _land?.Occupants ?? Array.Empty<ICell>();
            foreach (var cell in occupants)
            {
                var neigbords = _land?.GetNeigbords(cell) ?? Array.Empty<ICell>();
                newStates[cell] = _god?.GetNextCellState(cell, neigbords);
            }

            return newStates;
        }

    }
}
