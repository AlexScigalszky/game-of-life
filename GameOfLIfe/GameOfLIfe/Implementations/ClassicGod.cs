using GameOfLIfe.Interfaces;

namespace GameOfLIfe.Implementations
{
    public class ClassicGod : IGod
    {

        public bool IsAlive(ICell cell, IEnumerable<ICell> neigthbords)
        {
            var countAlive = neigthbords.Count(x => x?.CurrentState.State == "Alive");
            var isAlive = cell.CurrentState.State == "Alive";

            if (isAlive)
            {
                return countAlive == 2 || countAlive == 3;
            }
            else
            {
                return countAlive == 3;
            }
        }

        public ICellState GetRandomCellState()
        {
            var _random = new Random();
            return _random.NextSingle() > 0.5
                ? AliveConditionFactory.GetCondition("Alive")
                : AliveConditionFactory.GetCondition("Dead");
        }
    }
}
