using Zenject;

namespace Codebase.Infrastructure
{
    public class DIFactory
    {
        private readonly DiContainer _diContainer;

        public DIFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create<T>()
        {
            return _diContainer.Instantiate<T>();
        }
    }
}