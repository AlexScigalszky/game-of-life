using Engine.Interfaces;

namespace Engine.Implementations
{
    public class PrinterObserver : IGameObserver
    {
        private int _width = 5;

        public PrinterObserver(int width)
        {
            _width = width;
        }

        public void Update(IEnumerable<ICell> cells, int step)
        {
            //Console.Clear();

            Console.WriteLine($"Print step {step}");

            var str = "|";
            for (var j = 0; j < _width - 1; j++)
            {
                str += "----";
            }
            Console.WriteLine(str);
            for (var i = 0; i < _width - 1; i++)
            {
                str = "|";
                for (var j = 0; j < _width - 1; j++)
                {
                    str += Print(cells.ElementAt(i * j + 1)) + "|";
                }
                Console.WriteLine(str);

                str = "|";
                for (var j = 0; j < _width - 1; j++)
                {
                    str += "----";
                }
                Console.WriteLine(str);
            }
        }

        private string Print(ICell cell)
        {
            return cell.CurrentState.State == "Alive" ? " 0 " : "   ";
        }
    }
}
