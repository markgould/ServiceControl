﻿namespace ServiceControl.Operations
{
    using NServiceBus.CustomChecks;
    using NServiceBus.Logging;
    using Raven.Client;
    using Raven.Client.Indexes;
    using System;
    using System.Linq;

    class FailedAuditImportCustomCheck : CustomCheck
    {
        public FailedAuditImportCustomCheck(IDocumentStore store)
            : base("Audit Message Ingestion", "ServiceControl Health", TimeSpan.FromHours(1))
        {
            this.store = store;
        }

        public override CheckResult PerformCheck()
        {
            using (var session = store.OpenSession())
            {
                var query = session.Query<FailedAuditImport, FailedAuditImportIndex>();
                using (var ie = session.Advanced.Stream(query))
                {
                    if (ie.MoveNext())
                    {
                        var message = @"One or more audit messages have previously failed to import properly into ServiceControl and have been stored in the ServiceControl database.
Due to a defect however, ServiceControl would not be able to automatically reimport them. Please run ServiceControl in the maintenance mode and use embedded RavenStudio available by default at http://localhost:33333/storage to examine the payloads of failed messages to ensure no information has been lost.
Delete the failed import documents afterwards so that you don't see this warning message again.";

                        Logger.Warn(message);
                        return CheckResult.Failed(message);
                    }
                }
            }

            return CheckResult.Pass;
        }

        readonly IDocumentStore store;
        static readonly ILog Logger = LogManager.GetLogger(typeof(FailedAuditImportCustomCheck));
    }

    class FailedAuditImportIndex : AbstractIndexCreationTask<FailedAuditImport>
    {
        public FailedAuditImportIndex()
        {
            Map = docs => from cc in docs
                          select new FailedAuditImport
                          {
                              Id = cc.Id,
                              Message = cc.Message
                          };

            DisableInMemoryIndexing = true;
        }
    }
}