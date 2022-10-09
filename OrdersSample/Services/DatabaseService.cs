using System;
using OrdersSample.Interfaces;
using OrdersSample.Util;
using StackExchange.Redis;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace OrdersSample.Services
{
	public class DatabaseService : IDatabaseService
	{
        private readonly IDatabase _db;

        public DatabaseService()
		{
            _db = ConnectionHelper.Connection.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public bool SetData<T>(string key, T value)
        {
            TimeSpan expirationTime = new TimeSpan(30, 0, 0, 0);
            var isSet = _db.StringSet(key, JsonSerializer.Serialize(value), expirationTime);
            return isSet;
        }
    }
}

