using Engine.Interfaces;

namespace Engine.Implementations
{
    public class RandomEnder : IEnder
    {
        private static Random _random;

        public RandomEnder()
        {
            _random = new Random();
        }

        public bool ShouldContinue()
        {
            return _random.NextSingle() <= 0.8;
        }
    }
}
