using Engine.Interfaces;

namespace Engine.Implementations
{
    public class GameOfLife : IGame
    {
        private IGod? _god;
        private IGameObserver? _observer;
        private IGameLand<ICell>? _land;
        public int Step { get; private set; }

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

        }
        public void Start()
        {
            var occupants = _land?.Occupants ?? Array.Empty<ICell>();
            Step = 0;
            _observer?.Update(occupants, Step);
        }

        public void Next()
        {
            Step++;
            var occupants = _land?.Occupants ?? Array.Empty<ICell>();

            var nextStates = CalculateNextStates();

            UpdateNewStates(nextStates);

            _observer?.Update(occupants, Step);
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
