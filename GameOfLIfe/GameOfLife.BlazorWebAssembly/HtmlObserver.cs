using Engine.Interfaces;

namespace GameOfLife.BlazorWebAssembly
{
    public class HtmlObserver : IGameObserver
    {
        private int _width = 5;
        private int _step = 0;
        public string Logger { get; private set; } = "";

        public HtmlObserver(int width)
        {
            _width = width;
        }

        public void Update(IEnumerable<ICell> cells)
        {
            var newStep = $"Print step {_step}" + "\n";

            var str = "|";
            for (var j = 0; j < _width - 1; j++)
            {
                str += "----";
            }
            newStep += str + "\n";
            for (var i = 0; i < _width - 1; i++)
            {
                str = "|";
                for (var j = 0; j < _width - 1; j++)
                {
                    str += Print(cells.ElementAt(i * j + 1)) + "|";
                }
                newStep += str + "\n";

                str = "|";
                for (var j = 0; j < _width - 1; j++)
                {
                    str += "----";
                }
                newStep += str + "\n";
            }

            Logger = newStep + "\n" + Logger;
            _step++;
        }

        private string Print(ICell cell)
        {
            return cell.CurrentState.State == "Alive" ? " 0 " : "   ";
        }
    }
}
