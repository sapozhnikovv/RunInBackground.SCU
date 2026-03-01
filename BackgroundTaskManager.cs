using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;

namespace RunInBackground.SCU;

public class BackgroundTaskManager: IBackgroundTaskManager
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<BackgroundTaskManager> _logger;
    public BackgroundTaskManager(IServiceScopeFactory serviceScopeFactory, ILogger<BackgroundTaskManager> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }
    public void Run(Func<IServiceProvider, Task> funtor, uint retryCount = 0, uint msRetryOnErrorDelayStep = 100)
    {
        if (funtor is null) throw new ArgumentNullException(nameof(funtor));
        _ = Task.Run(async () =>
        {
            for (var i = 0; i <= retryCount; i++)
            {
                try
                {
                    await using var scope = _serviceScopeFactory.CreateAsyncScope();
                    await funtor(scope.ServiceProvider);
                    break;
                }
                catch (Exception e)
                {
                    var delay = TimeSpan.FromMilliseconds(RandomNumberGenerator.GetInt32(1, (int)msRetryOnErrorDelayStep) + (msRetryOnErrorDelayStep * (i + 1)));
                    _logger?.LogError(e, $"BackgroundTaskManager {(i < retryCount ? $"[retry in {delay.ToString()}]" : "")}");
                    if (i < retryCount) await Task.Delay(delay);
                }
            }
        });
    }
}
