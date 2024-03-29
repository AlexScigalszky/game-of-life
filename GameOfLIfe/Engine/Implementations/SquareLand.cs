﻿using Engine.Interfaces;

namespace Engine.Implementations
{
    public class SquareLand : IGameLand<ICell>
    {
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

        protected ICell[] _grid;
        protected int _nextAvailableSpace = 0;
        protected static int _width;
        protected int _maxAvailableSpace = 0;
        protected Dictionary<Guid, int> _indexes;

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
    }
}
