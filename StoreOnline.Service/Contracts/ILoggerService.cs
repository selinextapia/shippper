﻿

using StoreOnline.Service.Core;

namespace StoreOnline.Service.Contracts
{
    public interface ILoggerService<TService> where TService : IBaseService
    {
        void LogError(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogInformation(string message, params object[] args);
        void LogDebug(string message, params object[] args);
    }
}
