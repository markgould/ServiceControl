namespace ServiceControl.Infrastructure.SignalR
{
    using System.Threading.Tasks;
    using DomainEvents;

    /// <summary>
    /// Forwards all domain events via SignalR
    /// </summary>
    public class ServicePulseNotifier : IDomainHandler<IDomainEvent>
    {
        public ServicePulseNotifier(GlobalEventHandler broadcaster)
        {
            this.broadcaster = broadcaster;
        }

        public async Task Handle(IDomainEvent domainEvent)
        {
            var userInteraceEvent = domainEvent as IUserInterfaceEvent;
            if (userInteraceEvent != null)
            {
                await broadcaster.Broadcast(userInteraceEvent)
                    .ConfigureAwait(false);
            }
        }

        GlobalEventHandler broadcaster;
    }
}