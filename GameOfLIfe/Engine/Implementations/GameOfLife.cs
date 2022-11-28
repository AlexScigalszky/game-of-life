using Engine.Interfaces;

namespace Engine.Implementations
{
    public class GameOfLife : IGame
    {
        private struct GameOfLifeSnapshot : IGameSnapshot
        {
            public string Name { get; set; }
            public IGodSnapshot? God { get; set; }
            public IGameLandSnapshot? Land { get; set; }
            public IGame Originator { get; set; }
            public int Step { get; set; }

            public void RestoreState()
            {
                if (Originator is GameOfLife game)
                {
                    Console.WriteLine("GameOfLifeSnapshot - Restore");
                    God?.RestoreState();
                    Land?.RestoreState();
                    game.Step = Step;
                    game._observer?.Update(game);
                }
            }
        }

        private IGod? _god;
        private IGameObserver? _observer;
        private IGameLand<ICell>? _land;
        public int Step { get; private set; }

        public int Step { get; set; }

        public void Initialize(IGameLand<ICell> land, IGod god, IGameObserver observer)
        {
            _land = land;
            _god = god;
            _observer = observer;
            Step = 0;
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
            _observer?.Update(this);
        }

        public void Next()
        {
            Step++;
            var nextStates = CalculateNextStates();

            UpdateNewStates(nextStates);

            _observer?.Update(this);
        }

        private static void UpdateNewStates(Dictionary<ICell, ICellState?> nextStates)
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

        public IGameSnapshot CreateSnapshot()
        {
            Console.WriteLine("IGameSnapshot");
            return new GameOfLifeSnapshot()
            {
                Originator = this,
                God = _god?.CreateSnapshot(),
                Land = _land?.CreateSnapshot(),
                Step = Step
            };
        }

        public IEnumerable<ICell> GetCells()
        {
            return _land?.Occupants ?? Array.Empty<ICell>();
        }
    }
}
