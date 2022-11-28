using Engine.Interfaces;
using System.Text;

namespace GameOfLife.BlazorWebAssembly
{
    public class HtmlObserver : IGameObserver
    {
        private int _width = 5;
        public string Logger { get; private set; } = "";

        public HtmlObserver(int width)
        {
            _width = width;
        }

        public void Update(IEnumerable<ICell> cells, int step)
        {
            var newStep = "";

            newStep += $"<h1>Print step {step}</h1>";
            newStep += "<table>";
            newStep += "<tbody>";
            for (var i = 0; i < _width - 1; i++)
            {
                newStep += "<tr>";
                for (var j = 0; j < _width - 1; j++)
                {
                    newStep += Print(cells.ElementAt(i * j + 1));
                }
                newStep += "</tr>";
            }
            newStep += "</tbody>";
            newStep += "</table>";

            Logger = newStep + "\n" + Logger;
        }

        private string Print(ICell cell)
        {
            return cell.CurrentState.State == "Alive" ? "<td class=\"alive\"></td>" : "<td class=\"dead\"></td>" + "";
        }
    }
}
