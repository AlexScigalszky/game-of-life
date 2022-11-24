using Engine.Interfaces;

namespace Engine.Implementations
{
    public class SquareRandomIterationsBuilder : IGameBuilder
    {
        const int SquareSize = 20;
        private IGame _game;
        private IGod? _god;
        private IGameLand<ICell>? _land;
        private IGameObserver? _observer;
        private IEnder? _ender;

        public SquareRandomIterationsBuilder()
        {
            _game = new GameOfLife();
        }

        public void BuildGod()
        {
            _god = new ClassicGod();
        }

        public void BuildLand()
        {
            _land = new SquareLand(SquareSize);
        }

        public void BuildObserver()
        {
            _observer = new PrinterObserver(SquareSize);
        }

        public void BuildEnder()
        {
            _ender = new RandomEnder();
        }

        public IGame GetGame()
        {
            if (_land == null || _god == null || _observer == null || _ender == null)
            {
                throw new Exception("Missing parameter");
            }
            _game.Initialize(_land, _god, _observer, _ender);
            return _game;
        }

        public void Reset()
        {
            _game = new GameOfLife();
        }
    }
}
