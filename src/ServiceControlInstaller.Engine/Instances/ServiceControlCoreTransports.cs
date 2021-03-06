﻿namespace ServiceControlInstaller.Engine.Instances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceControlCoreTransports
    {
        public static List<TransportInfo> All => new List<TransportInfo>
        {
            new TransportInfo
            {
                Name = TransportNames.AmazonSQS,
                ZipName = "AmazonSQS",
                TypeName = "ServiceControl.Transports.SQS.SQSTransportCustomization, ServiceControl.Transports.SQS",
                SampleConnectionString = "AccessKeyId=<ACCESSKEYID>;SecretAccessKey=<SECRETACCESSKEY>;Region=<REGION>;QueueNamePrefix=<prefix>",
                Help = "'AccessKeyId', 'SecretAccessKey' and 'Region' are mandatory configurations.",
                Matches = name => name.Equals(TransportNames.AmazonSQS, StringComparison.OrdinalIgnoreCase) 
                                  || name.Equals("ServiceControl.Transports.SQS.SQSTransportCustomization, ServiceControl.Transports.SQS", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.AzureServiceBusEndpointOrientedTopology,
                TypeName = "ServiceControl.Transports.ASB.ASBEndpointTopologyTransportCustomization, ServiceControl.Transports.ASB",
                ZipName = "AzureServiceBus",
                SampleConnectionString = "Endpoint=sb://[namespace].servicebus.windows.net; SharedSecretIssuer=<owner>;SharedSecretValue=<someSecret>",
                Matches = name => name.Equals(TransportNames.AzureServiceBusEndpointOrientedTopology, StringComparison.OrdinalIgnoreCase) 
                                  || name.Equals("AzureServiceBus", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("ServiceControl.Transports.ASB.ASBEndpointTopologyTransportCustomization, ServiceControl.Transports.ASB", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("NServiceBus.AzureServiceBusTransport, NServiceBus.Azure.Transports.WindowsAzureServiceBus", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.AzureServiceBusForwardingTopology,
                TypeName = "ServiceControl.Transports.ASB.ASBForwardingTopologyTransportCustomization, ServiceControl.Transports.ASB",
                ZipName = "AzureServiceBus",
                SampleConnectionString = "Endpoint=sb://[namespace].servicebus.windows.net; SharedSecretIssuer=<owner>;SharedSecretValue=<someSecret>",
                Matches = name => name.Equals(TransportNames.AzureServiceBusForwardingTopology, StringComparison.OrdinalIgnoreCase) 
                                  || name.Equals("ServiceControl.Transports.ASB.ASBForwardingTopologyTransportCustomization, ServiceControl.Transports.ASB", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.AzureServiceBus,
                TypeName = "ServiceControl.Transports.ASBS.ASBSTransportCustomization, ServiceControl.Transports.ASBS",
                ZipName = "NetStandardAzureServiceBus",
                SampleConnectionString = "Endpoint=sb://[namespace].servicebus.windows.net; SharedSecretIssuer=<owner>;SharedSecretValue=<someSecret>",
                Matches = name => name.Equals(TransportNames.AzureServiceBus, StringComparison.OrdinalIgnoreCase) 
                                  || name.Equals("ServiceControl.Transports.ASBS.ASBSTransportCustomization, ServiceControl.Transports.ASBS", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.AzureStorageQueue,
                TypeName = "ServiceControl.Transports.ASQ.ASQTransportCustomization, ServiceControl.Transports.ASQ",
                ZipName = "AzureStorageQueue",
                SampleConnectionString = "DefaultEndpointsProtocol=[http|https];AccountName=<MyAccountName>;AccountKey=<MyAccountKey>",
                Matches = name => name.Equals(TransportNames.AzureStorageQueue, StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("ServiceControl.Transports.ASQ.ASQTransportCustomization, ServiceControl.Transports.ASQ", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("NServiceBus.AzureStorageQueueTransport, NServiceBus.Azure.Transports.WindowsAzureStorageQueues", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.MSMQ,
                TypeName = "ServiceControl.Transports.Msmq.MsmqTransportCustomization, ServiceControl.Transports.Msmq",
                ZipName = "Msmq",
                SampleConnectionString = string.Empty,
                Default = true,
                Matches = name => name.Equals(TransportNames.MSMQ, StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("ServiceControl.Transports.Msmq.MsmqTransportCustomization, ServiceControl.Transports.Msmq", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("NServiceBus.MsmqTransport, NServiceBus.Core", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.SQLServer,
                TypeName = "ServiceControl.Transports.SqlServer.SqlServerTransportCustomization, ServiceControl.Transports.SqlServer",
                ZipName = "SqlServer",
                SampleConnectionString = "Data Source=<SQLInstance>;Initial Catalog=nservicebus;Integrated Security=True",
                Help = "When integrated authentication is specified in the SQL connection string the the current installing user is used to create the required SQL tables structure not the service account.",
                Matches = name => name.Equals(TransportNames.SQLServer, StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("ServiceControl.Transports.SqlServer.SqlServerTransportCustomization, ServiceControl.Transports.SqlServer", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("NServiceBus.SqlServerTransport, NServiceBus.Transports.SQLServer", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.RabbitMQConventionalRoutingTopology,
                TypeName = "ServiceControl.Transports.RabbitMQ.RabbitMQConventionalRoutingTransportCustomization, ServiceControl.Transports.RabbitMQ",
                ZipName = "RabbitMQ",
                SampleConnectionString = "host=<HOSTNAME>;username=<USERNAME>;password=<PASSWORD>",
                Matches = name => name.Equals(TransportNames.RabbitMQConventionalRoutingTopology, StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("RabbitMQ", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("ServiceControl.Transports.RabbitMQ.RabbitMQConventionalRoutingTransportCustomization, ServiceControl.Transports.RabbitMQ", StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("NServiceBus.RabbitMQTransport, NServiceBus.Transports.RabbitMQ", StringComparison.OrdinalIgnoreCase)
            },
            new TransportInfo
            {
                Name = TransportNames.RabbitMQDirectRoutingTopology,
                TypeName = "ServiceControl.Transports.RabbitMQ.RabbitMQDirectRoutingTransportCustomization, ServiceControl.Transports.RabbitMQ",
                ZipName = "RabbitMQ",
                SampleConnectionString = "host=<HOSTNAME>;username=<USERNAME>;password=<PASSWORD>",
                Matches = name => name.Equals(TransportNames.RabbitMQDirectRoutingTopology, StringComparison.OrdinalIgnoreCase)
                                  || name.Equals("ServiceControl.Transports.RabbitMQ.RabbitMQDirectRoutingTransportCustomization, ServiceControl.Transports.RabbitMQ", StringComparison.OrdinalIgnoreCase)
            }
        };

        public static TransportInfo Find(string name)
        {
            return All.FirstOrDefault(p => p.Matches(name));
        }
    }
}
