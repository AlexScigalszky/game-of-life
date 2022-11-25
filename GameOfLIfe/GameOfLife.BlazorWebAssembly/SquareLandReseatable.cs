using Engine.Implementations;
using Engine.Interfaces;

namespace GameOfLife.BlazorWebAssembly
{
    public class SquareLandReseatable : SquareLand
    {
        public SquareLandReseatable(int width) : base(width)
        {
        }

        public void Reset()
        {
            _nextAvailableSpace = 0;
            _grid = new ICell[_maxAvailableSpace];
            _indexes = new Dictionary<Guid, int>();
        }
    }
}
