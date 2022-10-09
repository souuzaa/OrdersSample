using System;
namespace OrdersSample.Interfaces
{
	public interface IDatabaseService
	{
        T GetData<T>(string key);
        bool SetData<T>(string key, T value);
    }
}

