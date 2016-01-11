using Castle.MicroKernel;
using DataStore.Model.Events.Interface;

namespace DataStore.WebApi.EventDispatcher
{
    class WindsorEventContainer : IEventDispatcher
    {
        private readonly IKernel _kernel;

        public WindsorEventContainer(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IDomainEvent
        {
            foreach (var handler in _kernel.ResolveAll<IDomainHandler<TEvent>>())
            {
                handler.Handle(eventToDispatch);
            }
        }
    }
}