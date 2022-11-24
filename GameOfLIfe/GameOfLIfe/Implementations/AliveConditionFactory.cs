namespace GameOfLIfe.Implementations
{
    public class AliveConditionFactory
    {
        private static Dictionary<string, AliveCondition> _conditions = new Dictionary<string, AliveCondition>();

        public static AliveCondition GetCondition(string condition)
        {
            if (!_conditions.ContainsKey(condition))
            {
                _conditions.Add(condition, new AliveCondition(condition));
            }
            return _conditions[condition];
        }
    }
}
