using Engine.Interfaces;

namespace Engine.Implementations
{
    public class SquareLand : IGameLand<ICell>
    {
        private struct SquareLandSnapshot : IGameLandSnapshot
        {
            public string Name { get; set; }
            public ICellSnapshot[] Grid { get; set; }
            public int NextAvailableSpace { get; set; }
            public int Width { get; set; }
            public int MaxAvailableSpace { get; set; }
            public Dictionary<Guid, int> Indexes { get; set; }
            public IGameLand<ICell> Originator { get; set; }
            public ICell[] GridOriginator { get; internal set; }

            public void RestoreState()
            {
                if (Originator is SquareLand land)
                {
                    Console.WriteLine("IGameLandSnapshot - Restore");
                    land._nextAvailableSpace = NextAvailableSpace;
                    land._maxAvailableSpace = MaxAvailableSpace;
                    land._width = Width;
                    land._indexes = Indexes;
                    land._grid = GridOriginator;
                    foreach(var snap in Grid)
                    {
                        snap.RestoreState();
                    }
                }
            }
        }

        public int AvaliableSpaces
        {
            get
            {
                return _maxAvailableSpace;
            }
        }
        public IEnumerable<ICell> Occupants
        {
            get
            {
                return _grid;
            }
        }

        private ICell[] _grid;
        private int _nextAvailableSpace = 0;
        private int _width;
        private int _maxAvailableSpace = 0;
        private Dictionary<Guid, int> _indexes;

        public SquareLand(int width)
        {
            _width = width;
            _maxAvailableSpace = width * width;
            _nextAvailableSpace = 0;
            _grid = new ICell[_maxAvailableSpace];
            _indexes = new Dictionary<Guid, int>();
        }

        public void OccupyNextAvaliableSpace(ICell cell)
        {
            if (_nextAvailableSpace == _maxAvailableSpace)
            {
                throw new Exception("All spaces are full");
            }
            _grid[_nextAvailableSpace] = cell;
            _indexes.Add(cell.Guid, _nextAvailableSpace);
            _nextAvailableSpace++;
        }

        public IEnumerable<ICell> GetNeigbords(ICell occupant)
        {
            var (x, y) = GetIndexes(occupant);
            return new ICell?[] {
                GetSpace(x - 1, y - 1),
                GetSpace(x - 1, y),
                GetSpace(x - 1, y + 1),

                GetSpace(x, y - 1),
                GetSpace(x, y + 1),

                GetSpace(x + 1, y - 1),
                GetSpace(x + 1, y),
                GetSpace(x + 1, y + 1),
            }
            .Select(x => x!);
        }

        private (int x, int y) GetIndexes(ICell occupant)
        {
            var index = _indexes[occupant.Guid];
            return (
                x: index / _width,
                y: index % _width
            );
        }

        private ICell? GetSpace(int width, int heigth)
        {
            var address = width * _width + heigth;
            if (address >= 0 && address < _maxAvailableSpace - 1)
            {
                return _grid[address];
            }
            return default;

        }

        public IGameLandSnapshot CreateSnapshot()
        {
            Console.WriteLine("IGameLandSnapshot");
            return new SquareLandSnapshot()
            {
                Originator = this,
                GridOriginator = _grid,
                Grid = _grid.Select(x => x.CreateSnapshot()).ToArray(),
                NextAvailableSpace = _nextAvailableSpace,
                Width = _width,
                MaxAvailableSpace = _maxAvailableSpace,
                Indexes = _indexes
            };
        }
    }
}
