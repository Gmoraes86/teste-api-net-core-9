using System;

namespace DistributorAPI.Infrastructure.Helpers;

public static class RetryHelper
{
    public static async Task ExecuteWithRetryAsync(Func<Task> action, int maxRetries = 10, int delayMilliseconds = 300000)
    {
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                await action();
                return;
            }
            catch
            {
                if (attempt == maxRetries)
                    throw;

                await Task.Delay(delayMilliseconds);
            }
        }
    }
}
