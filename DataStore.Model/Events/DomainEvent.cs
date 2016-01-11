using DataStore.Model.Events.Interface;

namespace DataStore.Model.Events
{
   public static class DomainEvent
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Raise<T>(T @event) where T : IDomainEvent
        {
            Dispatcher.Dispatch(@event);
        }

    }
}