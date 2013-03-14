﻿namespace ServiceBus.Management.Modules
{
    using System.Linq;
    using Extensions;
    using Nancy;
    using Raven.Client;

    public class ErrorMessagesModule : NancyModule
    {
        public IDocumentStore Store { get; set; }

        public ErrorMessagesModule()
        {
            Get["/errors"] = _ =>
                {
                    using (var session = Store.OpenSession())
                    {
                        RavenQueryStatistics stats;
                        var results = session.Query<Message>()
                            .Statistics(out stats)
                            .Where(m => m.Status != MessageStatus.Successful)
                            .Sort(Request)
                            .Paging(Request)
                            .ToArray();

                        return Negotiate
                            .WithModel(results)
                            .WithTotalCount(stats);
                    }
                };

            Get["/endpoints/{name}/errors"] = parameters =>
            {
                using (var session = Store.OpenSession())
                {
                    string endpoint = parameters.name;

                    RavenQueryStatistics stats;
                    var results = session.Query<Message>()
                        .Statistics(out stats)
                        .Where(m => m.OriginatingEndpoint.Name == endpoint && m.Status != MessageStatus.Successful)
                        .Sort(Request)
                        .Paging(Request)
                        .ToArray();

                    return Negotiate
                            .WithModel(results)
                            .WithTotalCount(stats);

                }
            };
        }
    }

    
}