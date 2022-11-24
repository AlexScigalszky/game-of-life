using GameOfLIfe.Interfaces;

namespace GameOfLIfe.Implementations
{
    public class ClassicGod : IGod
    {
        public ICellState GetNextCellState(ICell cell, IEnumerable<ICell> neigthbords)
        {
            var countAlive = neigthbords.Count(x => x?.CurrentState.State == "Alive");
            var isAlive = cell.CurrentState.State == "Alive";

            if (isAlive)
            {
                if (countAlive == 2 || countAlive == 3)
                {
                    return new AliveCondition("Alive");
                }
                else
                {
                    return new AliveCondition("Dead");
                }
            }
            else
            {
                if (countAlive == 3)
                {
                    return new AliveCondition("Alive");
                }
                else
                {
                    return new AliveCondition("Dead");
                }
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
