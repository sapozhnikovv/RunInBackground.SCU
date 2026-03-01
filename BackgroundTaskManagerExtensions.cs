using Microsoft.Extensions.DependencyInjection;

namespace RunInBackground.SCU;

public static class BackgroundTaskManagerExtensions
{
    public static IServiceCollection RegisterBackgroundTaskManager(this IServiceCollection services) 
        => services.AddSingleton<IBackgroundTaskManager, BackgroundTaskManager>();
}