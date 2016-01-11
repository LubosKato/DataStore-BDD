namespace DataStore.Model.Events.Interface
{
    public interface IDomainHandler<T> where T : IDomainEvent
    {
        void Handle(T args); 
    }
}