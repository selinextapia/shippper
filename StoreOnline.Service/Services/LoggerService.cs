
using Microsoft.Extensions.Logging;

namespace StoreOnline.Service.Services
{
    public class LoggerService<TService> : Contracts.ILoggerService<TService> where TService : Core.IBaseService
    {
        private readonly ILogger<TService> logger;

        public void LogDebug(string message, params object[] args) => this.logger.LogDebug(message, args);

        public void LogError(string message, params object[] args) => this.logger.LogError(message, args);

        public void LogInformation(string message, params object[] args) => this.logger.LogInformation(message, args);

        public void LogWarning(string message, params object[] args) => this.logger.LogWarning(message, args);
    }
}
