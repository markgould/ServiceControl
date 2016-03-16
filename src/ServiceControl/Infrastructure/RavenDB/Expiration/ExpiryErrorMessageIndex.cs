namespace ServiceControl.Infrastructure.RavenDB.Expiration
{
    using System.Linq;
    using Raven.Client.Indexes;
    using ServiceControl.MessageFailures;

    public class ExpiryErrorMessageIndex : AbstractIndexCreationTask<FailedMessage>
    {
        public ExpiryErrorMessageIndex()
        {
            Map = messages => from message in messages
                where message.Status != FailedMessageStatus.Unresolved
                let last = message.ProcessingAttempts.Last()
                select new
                {
                    MessageId = last.MessageId,
                    Status = message.Status
                };

            DisableInMemoryIndexing = true;
        }
    }
}