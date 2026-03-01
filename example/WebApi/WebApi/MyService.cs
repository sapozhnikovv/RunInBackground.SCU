namespace WebApi
{
    public class MyService(ILogger<MyService> logger)
    {
        private static int Counter = 0;
        public async Task Do()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            Counter++;
            if (Counter <= 2) throw new Exception();
            logger.LogWarning("MyService - Finished");
            Counter = 0;
        }
    }
}
