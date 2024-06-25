namespace Hangfire.MAMQSqlExtension
{
    using Hangfire;
    using Hangfire.SqlServer;
    using System;
    using System.Collections.Generic;

    public static class MAMQIGlobalConfigurationExtension
    {
        public static IGlobalConfiguration<MAMQSqlServerStorage> UseMAMQSqlServerStorage(
            this IGlobalConfiguration configuration,
            string nameOrConnectionString,
            SqlServerStorageOptions options,
           IEnumerable<string> queues)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (nameOrConnectionString == null) throw new ArgumentNullException(nameof(nameOrConnectionString));
            if (options == null) throw new ArgumentNullException(nameof(options));

            var storage = new MAMQSqlServerStorage(nameOrConnectionString, options, queues);
            return configuration.UseStorage(storage);
        }

        public static IGlobalConfiguration<MAMQSqlServerStorage> UseMAMQSqlServerStorage(
            this IGlobalConfiguration configuration,
            System.Func<System.Data.Common.DbConnection> connectionFactory,
            SqlServerStorageOptions options,
           IEnumerable<string> queues)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            if (options == null) throw new ArgumentNullException(nameof(options));

            var storage = new MAMQSqlServerStorage(connectionFactory, options, queues);
            return configuration.UseStorage(storage);
        }

        public static IGlobalConfiguration<MAMQSqlServerStorage> UseMAMQSqlServerStorage(
            this IGlobalConfiguration configuration,
            System.Data.Common.DbConnection existingConnection,
            SqlServerStorageOptions options,
           IEnumerable<string> queues)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (existingConnection == null) throw new ArgumentNullException(nameof(existingConnection));
            if (options == null) throw new ArgumentNullException(nameof(options));

            var storage = new MAMQSqlServerStorage(existingConnection, options, queues);
            return configuration.UseStorage(storage);
        }
    }
}
