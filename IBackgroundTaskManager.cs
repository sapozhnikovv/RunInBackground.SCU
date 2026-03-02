namespace RunInBackground.SCU;

public interface IBackgroundTaskManager
{
    public void Run(Func<IServiceProvider, Task> functor, uint retryCount = 0, uint msRetryOnErrorDelayStep = 100);
}
