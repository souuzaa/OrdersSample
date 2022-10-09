using System;
using StackExchange.Redis;

namespace OrdersSample.Util
{
    public class ConnectionHelper
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        static ConnectionHelper()
        {
            ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
            });
        }
    }
}

