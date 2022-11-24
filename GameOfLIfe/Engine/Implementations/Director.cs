using Engine.Interfaces;

namespace Engine.Implementations
{
    public class Director : IBuildingDirector
    {
        private static IGameBuilder? _builder;

        public Director(IGameBuilder builder)
        {
            _builder = builder;
        }

        public IGame Make()
        {
            if (_builder == null)
            {
                throw new Exception("Cannot find the builder");
            }
            _builder.Reset();
            _builder.BuildLand();
            _builder.BuildGod();
            _builder.BuildObserver();
            _builder.BuildEnder();
            return _builder.GetGame();
        }
    }
}
